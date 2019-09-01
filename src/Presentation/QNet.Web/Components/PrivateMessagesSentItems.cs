using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class PrivateMessagesSentItemsViewComponent : QNetViewComponent
    {
        private readonly IPrivateMessagesModelFactory _privateMessagesModelFactory;

        public PrivateMessagesSentItemsViewComponent(IPrivateMessagesModelFactory privateMessagesModelFactory)
        {
            _privateMessagesModelFactory = privateMessagesModelFactory;
        }

        public IViewComponentResult Invoke(int pageNumber, string tab)
        {
            var model = _privateMessagesModelFactory.PrepareSentModel(pageNumber, tab);
            return View(model);
        }
    }
}
