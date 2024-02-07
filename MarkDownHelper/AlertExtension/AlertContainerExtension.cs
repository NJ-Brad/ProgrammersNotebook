using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;

namespace MarkDownHelper.AlertExtension
{
    // sample came from here : https://github.com/JeringTech/Markdig.Extensions.FlexiBlocks/blob/master/src/FlexiBlocks/MarkdownPipelineBuilderExtensions.cs#L274
    public static class AlertContainerExtensionExtension
    {
        public static MarkdownPipelineBuilder UseAlertContainerExtension(this MarkdownPipelineBuilder pipelineBuilder, bool docFxFormat)
        //public static MarkdownPipelineBuilder UseAlertContainerExtension(this MarkdownPipelineBuilder pipelineBuilder)
        {
            if (!pipelineBuilder.Extensions.Contains<AlertContainerExtension>())
            {
                //pipelineBuilder.Extensions.Add(new AlertContainerExtension(callback));
                //pipelineBuilder.Extensions.Add(new AlertContainerExtension());
                pipelineBuilder.Extensions.Add(new AlertContainerExtension(docFxFormat));
            }

            return pipelineBuilder;
        }
    }


    /// <summary>
    /// Extension to allow custom containers.
    /// </summary>
    /// <seealso cref="IMarkdownExtension" />
    public class AlertContainerExtension : IMarkdownExtension
    {
        bool docFxFormat = false;

        public AlertContainerExtension(bool docFxFormat)
        {
            this.docFxFormat = docFxFormat;
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.BlockParsers.Contains<AlertContainerParser>())
            {
                // Insert the parser before any other parsers
                pipeline.BlockParsers.Insert(0, new AlertContainerParser());
            }

            // Plug the inline parser for CustomContainerInline
            var inlineParser = pipeline.InlineParsers.Find<EmphasisInlineParser>();
            //if (inlineParser != null && !inlineParser.HasEmphasisChar(':'))
            if (inlineParser != null && !inlineParser.HasEmphasisChar('!'))
            {
                // inlineParser.EmphasisDescriptors.Add(new EmphasisDescriptor(':', 2, 2, true));
                inlineParser.EmphasisDescriptors.Add(new EmphasisDescriptor('!', 2, 2, true));
                inlineParser.TryCreateEmphasisInlineList.Add((emphasisChar, delimiterCount) =>
                {
                    //if (delimiterCount == 2 && emphasisChar == ':')
                    if (delimiterCount == 2 && emphasisChar == '!')
                    {
                        return new AlertContainerInline();
                    }
                    return null;
                });
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            if (renderer is HtmlRenderer htmlRenderer)
            {
                if (!htmlRenderer.ObjectRenderers.Contains<HtmlAlertContainerRenderer>())
                {
                    // Must be inserted before CodeBlockRenderer
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlAlertContainerRenderer());
                }
                if (!htmlRenderer.ObjectRenderers.Contains<HtmlAlertContainerInlineRenderer>())
                {
                    // Must be inserted before EmphasisRenderer
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlAlertContainerInlineRenderer());
                }
            }

        }
    }
}