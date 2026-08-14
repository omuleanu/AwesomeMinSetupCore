using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Omu.Awem.Helpers;
using Omu.AwesomeMvc;

namespace MinSetupCore.Helpers.Awesome
{
    public static class CrudHelpers
    {
        private static IUrlHelper GetUrlHelper<T>(IHtmlHelper<T> html)
        {
            return ((IUrlHelperFactory)html.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory))).GetUrlHelper(html.ViewContext);
        }

        private static string getUrl(
            IUrlHelper url,
            string action,
            string controller,
            string area,
            bool usePageMethods)
        {
            // for razor pages
            if (usePageMethods)
            {
                return url.Page(string.Empty, action);
            }

            return url.Action(action, controller, new { area });
        }

        /*beging*/
        /// <summary>
        /// initialize PopupForms for grid crud
        /// </summary>
        /// <param name="html"></param>
        /// <param name="gridId"></param>
        /// <param name="crudController">controller containing the crud actions</param>
        /// <param name="createPopupHeight">height of the create/edit popup</param>
        /// <param name="maxWidth"> max popup width</param>        
        /// <param name="area"></param>
        /// <param name="inlineContId">html id for the inline popup container</param>
        /// <param name="reload">reload grid on success (default true)</param>
        /// <param name="cfg">action to modify PopupFormOpt</param>
        /// <param name="usePageMethods">use url.Page (Razor Pages) instead of url.Action to generate url</param>
        public static IHtmlContent InitCrudPopupsForGrid<T>(
            this IHtmlHelper<T> html,
            string gridId,
            string crudController,
            int createPopupHeight = 430,
            int maxWidth = 0,
            string area = null,
            string inlineContId = null,
            bool reload = true,
            Action<PopupFormOpt, string> cfg = null,
            bool usePageMethods = false)
        {
            var url = GetUrlHelper(html);
            gridId = html.Awe().GetContextPrefix() + gridId;

            var loadOnSave = "loadOnSave";
            var loadOnDelete = "loadOnDelete";

            var format = "aweUtils.{0}('" + gridId + "')";

            var onCreatedFunc = string.Format(format, reload ? loadOnSave : "itemCreated");
            var onSaveFunc = string.Format(format, reload ? loadOnSave : "itemEdited");
            var onDeletedFunc = string.Format(format, reload ? loadOnDelete : "itemDeleted");
            var delConfirmFunc = string.Format(format, "delConfirmLoad");

            var showHeader = true;

            if (inlineContId != null)
            {
                showHeader = false;
            }

            var opt = new PopupFormOpt
            {
                Name = "create" + gridId,
                Group = gridId,
                Height = createPopupHeight,
                MaxWidth = maxWidth,
                Url = getUrl(url, "Create", crudController, area, usePageMethods),
                Title = "Create item",
                Modal = true,
                OnSuccess = onCreatedFunc,
                ShowHeader = showHeader,
                InlTrg = inlineContId
            };

            if (cfg != null)
            {
                cfg(opt, "create");
            }

            var create = html.Awe()
                .InitPopupForm(opt);

            opt = new PopupFormOpt
            {
                Name = "edit" + gridId,
                Group = gridId,
                Height = createPopupHeight,
                MaxWidth = maxWidth,
                Url = getUrl(url, "Edit", crudController, area, usePageMethods),
                Title = "Edit item",
                Modal = true,
                OnSuccess = onSaveFunc,
                ShowHeader = showHeader,
                InlTrg = inlineContId
            };

            if (cfg != null)
            {
                cfg(opt, "edit");
            }

            var edit = html.Awe()
                .InitPopupForm(opt);

            opt = new PopupFormOpt
            {
                Name = "delete" + gridId,
                Group = gridId,
                Url = getUrl(url, "Delete", crudController, area, usePageMethods),
                Title = "Delete item",
                OnSuccess = onDeletedFunc,
                OnLoad = delConfirmFunc, // calls grid.api.select and animates the row
                Height = 200,
                Modal = true,
                ShowHeader = showHeader,
                InlTrg = inlineContId
            };

            if (cfg != null)
            {
                cfg(opt, "delete");
            }

            var delete = html.Awe()
                  .InitPopupForm(opt);

            var result = create.ToString() + edit + delete;

            return new HtmlString(result);
        }
        /*endg*/

        /// <summary>
        /// Initialize PopupForms for grid nest crud
        /// </summary>
        /// <param name="html"></param>
        /// <param name="gridId"></param>
        /// <param name="crudController">controller containing the crud actions</param>        
        /// <param name="area"></param>
        public static IHtmlContent InitCrudForGridNest<T>(
            this IHtmlHelper<T> html,
            string gridId,
            string crudController,
            string area = null,
            bool usePageMethods = false)
        {
            var url = GetUrlHelper(html);
            gridId = html.Awe().GetContextPrefix() + gridId;


            var format = "aweUtils.{0}('" + gridId + "')";
            var onSaveFunc = string.Format(format, "loadOnSave");
            var onDeleteFunc = string.Format(format, "loadOnDelete");

            var delConfirmFunc = string.Format(format, "delConfirmLoad");

            var result =
                html.Awe()
                    .InitPopupForm(new PopupFormOpt
                    {
                        Name = "create" + gridId,
                        Group = gridId,
                        Url = getUrl(url, "Create", crudController, area, usePageMethods),
                        Inline = true,
                        ShowHeader = false,
                        OnSuccess = onSaveFunc
                    })
                    .ToString()

                + html.Awe()
                      .InitPopupForm(new PopupFormOpt
                      {
                          Name = "edit" + gridId,
                          Group = gridId,
                          Url = getUrl(url, "Edit", crudController, area, usePageMethods),
                          Inline = true,
                          ShowHeader = false,
                          OnSuccess = onSaveFunc
                      })

                + html.Awe()
                      .InitPopupForm(new PopupFormOpt
                      {
                          Name = "delete" + gridId,
                          Group = gridId,
                          Url = getUrl(url, "Delete", crudController, area, usePageMethods),
                          Inline = true,
                          ShowHeader = false,
                          OnSuccess = onDeleteFunc
                      });

            return new HtmlString(result);
        }

        /// <summary>
        /// Init Confirm Delete PopupForm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="gridId"></param>
        /// <param name="crudController"></param>
        /// <param name="action"></param>
        /// <param name="area"></param>
        /// <param name="url"></param>
        /// <param name="reload"></param>
        /// <param name="usePageMethods"></param>
        /// <returns></returns>
        public static IHtmlContent InitDeletePopupForGrid<T>(
            this IHtmlHelper<T> html,
            string gridId,
            string crudController = null,
            string action = "Delete",
            string area = null,
            string url = null,
            bool reload = true,
            bool usePageMethods = false)
        {
            var urlh = GetUrlHelper(html);
            gridId = html.Awe().GetContextPrefix() + gridId;

            var funcFormat = "aweUtils.{0}('" + gridId + "')";
            var onSuccessFunc = string.Format(funcFormat, reload ? "loadOnDelete" : "itemDeleted");

            var result =
                html.Awe()
                    .InitPopupForm(new PopupFormOpt
                    {
                        Name = "delete" + gridId,
                        Group = gridId,
                        Url = url ?? getUrl(urlh, action, crudController, area, usePageMethods),
                        OnSuccess = onSuccessFunc,
                        OnLoad = "aweUtils.delConfirmLoad('" + gridId + "')", // delConfirmFunc calls grid.api.select and animates the row
                        Height = 180,
                        Modal = true,
                    })
                    .ToString();

            return new HtmlString(result);
        }
    }
}