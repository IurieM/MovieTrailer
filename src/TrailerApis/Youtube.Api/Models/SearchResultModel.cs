using System.Collections.Generic;

namespace Youtube.Api.Models
{
    public class SearchResultModel
    {
        public IEnumerable<ItemInfo> Items { get; set; }

        public sealed class ItemInfo
        {
            public SnippetInfo Snippet { get; set; }
            public Identifier Id { get; set; }

            public sealed class Identifier
            {
                public string VideoId { get; set; }
            }

            public sealed class SnippetInfo
            {
                public string Title { get; set; }
            }
        }
    }
}
