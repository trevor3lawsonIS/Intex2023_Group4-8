namespace Intex2023.Models.ViewModels
{
    public class BurialViewModel
    {
        public IQueryable<Burialmain> Burialmains { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
