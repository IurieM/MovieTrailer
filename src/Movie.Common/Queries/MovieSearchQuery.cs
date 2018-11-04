namespace Movie.Common.Queries
{
    public class MovieSearchQuery
    {
        public string Search { get; set; }
        public int ItemsPerPage { get; set; }

        public MovieSearchQuery()
        {
            ItemsPerPage = 25;
        }
    }
}
