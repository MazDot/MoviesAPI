namespace MoviesAPI.Entities.DTO
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        private int basePageSize = 10;
        private readonly int maxAmount = 50;
        public int PageSize
        {
            get
            {
                return basePageSize;
            }
            set
            {
                basePageSize = (value > maxAmount) ? maxAmount : value;
            }
        }

    }
}
