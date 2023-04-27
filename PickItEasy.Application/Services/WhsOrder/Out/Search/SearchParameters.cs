namespace PickItEasy.Application.Services.WhsOrder.Out.Search
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

        public SearchParameters()
        {
            this.isBarcode = false;
            this.isTerm = true;
            this.isStatus = true;
        }

        public bool IsBarcode
        {
            get => isBarcode;
            set
            {
                isBarcode = value;
            }
        }

        public bool IsTerm
        {
            get => isTerm;
            set
            {
                isTerm = value;
            }
        }

        public bool IsStatus
        {
            get => isStatus;
            set
            {
                isStatus = value;
            }
        }

        public string? SearchBarcode
        {
            get => searchBarcode;
            set
            {
                searchBarcode = value;
            }
        }

        public string? SearchTerm
        {
            get => searchTerm;
            set
            {
                //if (isBarcode)
                //    searchTerm = null;
                //else
                searchTerm = value;
            }
        }

        public Guid? StatusId
        {
            get => statusId;
            set
            {
                statusId = value;
            }
        }

        public Guid? WarehouseId
        {
            get => warehouseId;
            set
            {
                warehouseId = value;
            }
        }

        public Guid? UserId
        {
            get => userId;
            set
            {
                userId = value;
            }
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetSearchByBarcode(string? barcode)
        {
            isBarcode = true;
            isTerm = false;
            isStatus = false;

            SearchBarcode = barcode;
            //SearchTerm = null;
            StatusId = Guid.Empty;

            NotifyStateChanged();
        }

        public void ClearSearchByBarcode()
        {
            isBarcode = false;
            isTerm = true;
            isStatus = true;

            SearchBarcode = null;

            NotifyStateChanged();
        }

        public void SetSearchByTerm()
        {
            isTerm = true;

            NotifyStateChanged();
        }

        public void ClearSearchByTerm()
        {
            //isTerm = false;

            SearchTerm = null;

            NotifyStateChanged();
        }

        public void SetSearchByStatus(Guid statusId)
        {
            isStatus = true;

            StatusId = statusId;

            NotifyStateChanged();
        }

        public void ClearSearchByStatus(Guid statusId)
        {
            isStatus = false;

            StatusId = Guid.Empty;

            NotifyStateChanged();
        }
    }
}
