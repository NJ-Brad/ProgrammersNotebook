using Markdig;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Renderers;
using Markdig.Syntax.Inlines;
using System.Text.RegularExpressions;

namespace MarkDownHelper
{
    // sample came from here : https://github.com/JeringTech/Markdig.Extensions.FlexiBlocks/blob/master/src/FlexiBlocks/MarkdownPipelineBuilderExtensions.cs#L274
    public static class PredefinedImageExtensionExtension
    {
        public static MarkdownPipelineBuilder UsePredefinedImageExtension(this MarkdownPipelineBuilder pipelineBuilder)
        {
            if (!pipelineBuilder.Extensions.Contains<PredefinedImageExtension>())
            {
                pipelineBuilder.Extensions.Add(new PredefinedImageExtension());
            }

            return pipelineBuilder;
        }
        //public static MarkdownPipelineBuilder PredefinedImageExtension(this MarkdownPipelineBuilder pipelineBuilder, IFlexiPictureBlocksExtensionOptions options = null)
        //{
        //    if (!pipelineBuilder.Extensions.Contains<PredefinedImageExtension>())
        //    {
        //        pipelineBuilder.Extensions.Add(< PredefinedImageExtension > ());
        //    }

        //    if (options != null)
        //    {
        //        AddContextObjectWithTypeAsKey(pipelineBuilder, options);
        //    }

        //    return pipelineBuilder;
        //}
    }


    public class PredefinedImageExtension : IMarkdownExtension
    {
        public PredefinedImageExtension()
        {
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<PredefinedImageParser>())
            {
                pipeline.InlineParsers.Insert(0, new PredefinedImageParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
        }
    }

    public partial class PredefinedImageParser : InlineParser
    {
        public PredefinedImageParser()
        {
            OpeningCharacters = new[] { '[' };
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var precedingCharacter = slice.PeekCharExtra(-1);
            if (!precedingCharacter.IsWhiteSpaceOrZero())
            {
                return false;
            }

            var regex = PredefinedImageTagRegex();
            var match = regex.Match(slice.ToString());

            if (!match.Success)
            {
                return false;
            }

            var imagename = match.Groups["imagename"].Value;
            var literal = $"<img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==\" alt=\"Red Dot\" />";

            // markdown
            // ! [Red Dot](data: image / png; base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==)
            // html
            // <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==" alt="Red Dot" />

            processor.Inline = new HtmlInline(literal)
            {
                Span =
            {
                Start = processor.GetSourcePosition(slice.Start, out var line, out var column)
            },
                Line = line,
                Column = column,
                IsClosed = true
            };
            processor.Inline.Span.End = processor.Inline.Span.Start + match.Length - 1;
            slice.Start += match.Length;
            return true;
        }

        //[GeneratedRegex(@"\[predefinedimage:(?<username>\w+)]")]
        [GeneratedRegex(@"\[predefinedimage:(?<imagename>[a-zA-Z0-9_-]+)]")]
        private static partial Regex PredefinedImageTagRegex();
    }
}
