namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class SearchParameters
    {
        private bool isBarcode;
        private string? searchTerm;
        private Guid? statusId;
        private Guid? warehouseId;
        private Guid? userId;

        public bool IsBarcode
        {
            get => isBarcode;
            set
            {
                isBarcode = value;
                NotifyStateChanged();
            }
        }

        public string? SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                NotifyStateChanged();
            }
        }
        public Guid? StatusId
        {
            get => statusId;
            set
            {
                statusId = value;
                NotifyStateChanged();
            }
        }
        public Guid? WarehouseId
        {
            get => warehouseId;
            set
            {
                warehouseId = value;
                NotifyStateChanged();
            }
        }
        public Guid? UserId
        {
            get => userId;
            set
            {
                userId = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
