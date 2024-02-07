using Markdig.Parsers;

namespace MarkDownHelper.AlertExtension
{
    /// <summary>
    /// The block parser for a <see cref="CustomContainer"/>.
    /// </summary>
    /// <seealso cref="FencedBlockParserBase{CustomContainer}" />

    //    public class AlertContainerParser : FencedBlockParserBase<AlertContainer>
    public class AlertContainerParser : FencedBlockParserBase<AlertContainer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlertContainerParser"/> class.
        /// </summary>
        public AlertContainerParser()
        {
            //OpeningCharacters = [':'];
            OpeningCharacters = ['!'];

            // We don't need a prefix
            InfoPrefix = null;
        }

        protected override AlertContainer CreateFencedBlock(BlockProcessor processor)
        {
            return new AlertContainer(this);
        }
    }
}