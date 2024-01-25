namespace FinalExamSaid.Areas.Admin.ViewModels
{
    public class PaginationVM<T> where T : class,new()
    {
        public decimal TotalPage { get; set; }
        public int Limit { get; set; }
        public int CurrentPage { get; set; }
        public ICollection<T> Items { get; set; }
    }
}
