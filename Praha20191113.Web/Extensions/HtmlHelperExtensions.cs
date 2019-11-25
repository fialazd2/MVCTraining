using System.Web.Mvc;

namespace Praha20191113.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Alert(this HtmlHelper helper, string message)
        {
            string htmlToReturn = $@"<div class='alert alert-success' role='alert'>{message}</div>";

            return new MvcHtmlString(htmlToReturn);
        }

        #region -------------------------------- Modal --------------------------------------------
        public static MvcHtmlString ModalButton(this HtmlHelper helper, string modalTitle, string modalBody)
        {
            string htmlToReturn = $@"<div class='modal' id='myModal' tabindex='-1' role='dialog'>
                                        <div class='modal-dialog' role='document'>
                                            <div class='modal-content'>
                                                <div class='modal-header'>
                                                    <h5 class='modal-title'>{modalTitle}</h5>
                                                        <button type='button' class='close' data-dismiss='modal' aria-label='Close'>
                                                            <span aria-hidden='true'>&times;</span>
                                                        </button>
                                                </div>
                                            <div class='modal-body'>
                                                <p>{modalBody}</p>
                                            </div>
                                            <div class='modal-footer'>
                                                <button type='button' class='btn btn-secondary' data-dismiss='modal'>Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>";

            return new MvcHtmlString(htmlToReturn);
        }
        #endregion

    }
}