using System.Collections.Generic;

namespace Vimeo.Api.Models
{
    public class SearchResultModel
    {
        public IEnumerable<Item> Data { get; set; }

        public sealed class Item
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }
    }
}
