namespace Library.Core
{
    public class BookPreviewDto
    {
        public long Isbn { get; set; }
        public string Book { get; set; }
        public string Thumb { get; set; }

        public string AuthorName { get; set; }
        public short Pages { get; set; }

    }
}
