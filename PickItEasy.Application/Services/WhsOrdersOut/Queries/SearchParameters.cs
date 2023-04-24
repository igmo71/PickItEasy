using NetBarcode;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class SearchParameters
    {
        private bool isBarcode;
        private bool isTerm;
        private bool isStatus;
        private bool isWarehouse;
        private bool isUser;
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
                //NotifyStateChanged();
            }
        }

        public bool IsTerm
        {
            get => isTerm;
            set
            {
                isTerm = value;
                //NotifyStateChanged();
            }
        }

        public bool IsStatus
        {
            get => isStatus;
            set
            {
                isStatus = value;
                //NotifyStateChanged();
            }
        }

        public string? SearchBarcode
        {
            get => searchBarcode;
            set
            {
                isBarcode = true;
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
            isBarcode = true;
            isStatus = false;

            SearchBarcode = barcode;
        }

        public void ClearSearchByBarcode()
        {
            isBarcode = false;
            isStatus = true;

            SearchBarcode = null;
        }

        public void SetSearchByTerm()
        {
            isTerm = true;
        }

        public void ClearSearchByTerm()
        {
            isTerm = false;

            SearchTerm = null;
        }

        public void ClearSearchByTermAndBarcode()
        {
            isBarcode = false;

            SearchTerm = null;
            SearchBarcode = null;
        }

        public void SetSearchByStatus(Guid statusId)
        {
            isStatus = true;

            StatusId = statusId;
        }

        public void ClearSearchByStatus(Guid statusId)
        {
            isStatus = false;

            StatusId = Guid.Empty;
        }
    }
}
