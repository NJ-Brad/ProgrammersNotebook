using Markdig;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Renderers;
using Markdig.Syntax.Inlines;
using System.Text.RegularExpressions;

// Found the foundation for this here : https://khalidabuhakmeh.com/how-to-write-a-dotnet-markdig-extension-for-markdown-processing
// Found how to use Func<> delegate here : https://stackoverflow.com/questions/2082615/pass-method-as-parameter-using-c-sharp
// Found how to pass the arguments here : https://www.codeproject.com/Articles/1200545/Writing-custom-Markdig-extensions
// More extensions here : https://github.com/arthurrump/MarkdigExtensions
namespace MarkDownHelper
{
    // sample came from here : https://github.com/JeringTech/Markdig.Extensions.FlexiBlocks/blob/master/src/FlexiBlocks/MarkdownPipelineBuilderExtensions.cs#L274
    public static class EmbeddedLinkResolverExtensionExtension
    {
        public static MarkdownPipelineBuilder UseEmbeddedLinkResolverExtension(this MarkdownPipelineBuilder pipelineBuilder, string replacement)
        {
            if (!pipelineBuilder.Extensions.Contains<EmbeddedLinkResolverExtension>())
            {
                pipelineBuilder.Extensions.Add(new EmbeddedLinkResolverExtension(replacement));
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



    public class EmbeddedLinkResolverExtension : IMarkdownExtension
    {
        string replacement = string.Empty;

        public EmbeddedLinkResolverExtension(string replacement)
        {
            this.replacement = replacement;
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<EmbeddedLinkResolverParser>())
            {
                pipeline.InlineParsers.Insert(0, new EmbeddedLinkResolverParser(replacement));
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
        }
    }

    public partial class EmbeddedLinkResolverParser : InlineParser
    {
        string replacement = string.Empty;
        public EmbeddedLinkResolverParser(string replacement)
        {
            this.replacement = replacement;
            OpeningCharacters = new[] { '[' };
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var precedingCharacter = slice.PeekCharExtra(-1);
            if (!precedingCharacter.IsWhiteSpaceOrZero())
            {
                return false;
            }

            var regex = EmbeddedLinkTagRegex();
            string sliceString = slice.ToString();

            if (!sliceString.StartsWith("[embeddedlink:"))
                return false;

            int idx = sliceString.IndexOf(']');
            if (idx == -1)
                return false;


            //var match = regex.Match(slice.ToString());

            //if (!match.Success)
            //{
            //    return false;
            //}

            //var linkname = match.Groups["linkname"].Value;

            int sliceStart = "[embeddedlink:".Length;
            var linkname = sliceString.Substring(sliceStart, idx - sliceStart);

            //var literal = $"<a href=\"https://github.com/{linkname}\"/>{linkname}</a>";
            var literal = $"<a href=\"{replacement}/{linkname}\"/>{linkname}</a>";

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

            //processor.Inline.Span.End = processor.Inline.Span.Start + sliceString.Length - 1;
            processor.Inline.Span.End = processor.Inline.Span.Start + idx - 1;
            slice.Start += idx + 1;
            return true;
        }

        [GeneratedRegex(@"\[embeddedlink:(?<linkname>[a-zA-Z0-9_-]+)]")]
        private static partial Regex EmbeddedLinkTagRegex();
    }
}
