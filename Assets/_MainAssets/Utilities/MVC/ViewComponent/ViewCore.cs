using UnityEngine;
using Utilities.MVC.ModelComponent;

namespace Utilities.MVC.ViewComponent
{
    public class ViewCore<TModel> : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }

    public class ViewCore : ViewCore<BaseModel>
    {
    }
}