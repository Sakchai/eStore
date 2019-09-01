using Microsoft.AspNetCore.Mvc;
using QNet.Web.Factories;
using QNet.Web.Framework.Components;

namespace QNet.Web.Components
{
    public class PrivateMessagesInboxViewComponent : QNetViewComponent
    {
        private readonly IPrivateMessagesModelFactory _privateMessagesModelFactory;

        public PrivateMessagesInboxViewComponent(IPrivateMessagesModelFactory privateMessagesModelFactory)
        {
            _privateMessagesModelFactory = privateMessagesModelFactory;
        }

        public IViewComponentResult Invoke(int pageNumber, string tab)
        {
            var model = _privateMessagesModelFactory.PrepareInboxModel(pageNumber, tab);
            return View(model);
        }
    }
}
