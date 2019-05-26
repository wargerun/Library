using Library.Data;
using Library.Data.BusinessLogic;
using Library.Interfaces;

namespace Library.Helpers
{
    public sealed class ManagerViewer : IDbManager<VIEWER>
    {
        public void AddNewRow(VIEWER viewer)
        {
            ViewerBl.AddNewViewer(viewer);
        }

        public void UpdateRow(VIEWER entity)
        {
            ViewerBl.UpdateViewer(entity);
        }

        public void RemoveRow(VIEWER viewer)
        {
            ViewerBl.ViewersRemove(new[] { viewer.ID });
        }
    }
}