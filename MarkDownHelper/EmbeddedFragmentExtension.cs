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
    public static class EmbeddedFragmentExtensionExtension
    {
        public static MarkdownPipelineBuilder UseEmbeddedFragmentExtension(this MarkdownPipelineBuilder pipelineBuilder, Func<string, string> callback)
        {
            if (!pipelineBuilder.Extensions.Contains<EmbeddedFragmentExtension>())
            {
                pipelineBuilder.Extensions.Add(new EmbeddedFragmentExtension(callback));
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



    public class EmbeddedFragmentExtension : IMarkdownExtension
    {
        Func<string, string> callback;

        public EmbeddedFragmentExtension(Func<string, string> callback)
        {
            this.callback = callback;
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<EmbeddedFragmentParser>())
            {
                pipeline.InlineParsers.Insert(0, new EmbeddedFragmentParser(callback));
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
        }
    }

    public partial class EmbeddedFragmentParser : InlineParser
    {
        Func<string, string> callback;
        public EmbeddedFragmentParser(Func<string, string> callback)
        {
            this.callback = callback;
            OpeningCharacters = new[] { '[' };
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var precedingCharacter = slice.PeekCharExtra(-1);
            if (!precedingCharacter.IsWhiteSpaceOrZero())
            {
                return false;
            }

            var regex = EmbeddedFragmentTagRegex();
            var match = regex.Match(slice.ToString());

            if (!match.Success)
            {
                return false;
            }

            var blockname = match.Groups["blockname"].Value;
            //var literal = $"<a href=\"https://github.com/{blockname}\"/>{blockname}</a>";

            var literal = callback(blockname);

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

        [GeneratedRegex(@"\[embeddedfragment:(?<blockname>[a-zA-Z0-9_-]+)]")]
        private static partial Regex EmbeddedFragmentTagRegex();
    }

    public class EmbeddedFragmentEventArgs : EventArgs
    {
        public string Key { get; set; } = string.Empty;
        public PageFragment Value { get; set; } = new();
        public string Operation { get; set; } = "GET";
        public List<string> Names { get; set; } = new();
    }
}
