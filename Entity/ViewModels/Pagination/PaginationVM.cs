namespace Entity.ViewModels.Pagination;

public class PaginationVM<T>
{
    public List<T> Models { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public bool NextPage { get; set; }
    public bool Previous { get; set; }
}
