namespace BookHistory.Models
{
    public class AuditParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        // To filter and show dates between two years
        public uint startYear { get; set; }
        public uint endYear { get; set; } = (uint)DateTime.Now.Year;
    }
}
