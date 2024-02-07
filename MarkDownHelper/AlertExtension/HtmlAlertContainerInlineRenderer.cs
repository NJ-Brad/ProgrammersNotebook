using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace MarkDownHelper.AlertExtension
{
    /// <summary>
    /// A HTML renderer for a <see cref="AlertContainerInline"/>.
    /// </summary>
    /// <seealso cref="HtmlObjectRenderer{AlertContainerInline}" />
    public class HtmlAlertContainerInlineRenderer : HtmlObjectRenderer<AlertContainerInline>
    {
        protected override void Write(HtmlRenderer renderer, AlertContainerInline obj)
        {
            renderer.Write("<span").WriteAttributes(obj).Write('>');
            renderer.WriteChildren(obj);
            renderer.Write("</span>");
        }
    }
}
