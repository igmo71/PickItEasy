using NetBarcode;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class SearchParameters
    {
        private bool isBarcode;
        private bool isStatus;
        private string? searchBarcode;
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
        public bool IsStatus
        {
            get => isStatus;
            set
            {
                isStatus = value;
                NotifyStateChanged();
            }
        }

        public string? SearchBarcode
        {
            get => searchBarcode;
            set
            {
                searchBarcode = value;
                NotifyStateChanged();
            }
        }

        public string? SearchTerm
        {
            get => searchTerm;
            set
            {
                if (isBarcode)
                    searchTerm = null;
                else
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

        public void SetSearchByBarcode(string? barcode)
        {
            SearchBarcode = barcode;
            IsBarcode = true;
            IsStatus = false;
        }

        public void ClearSearchByBarcode()
        {
            SearchBarcode = null;
            IsBarcode = false;
            IsStatus = true;
        }

        public void ClearSearchByTermAndBarcode()
        {
            SearchTerm = null;
            SearchBarcode = null;
            IsBarcode = false;
        }

        public void SetSearchByStatus(Guid statusId)
        {
            StatusId = statusId;
            IsStatus = true;
        }
    }
}
