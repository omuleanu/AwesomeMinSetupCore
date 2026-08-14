using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Omu.Awem.Helpers;
using Omu.AwesomeMvc;

namespace MinSetupCore.Utils.Awesome
{
    public static class GridUtils
    {
        public const int EditBtnWidth = 90;
        public const int DeleteBtnWidth = 100;
        public const int EditDeleteColumnWidth = 120;

        private const string editContent = "Edit";
        private const string deleteContent = "Delete";

        private static string GetPopupName<T>(this IHtmlHelper<T> html, string action, string gridId)
        {
            return action + html.Awe().GetContextPrefix() + gridId;
        }

        public static string InlineCancelBtn<T>(this IHtmlHelper<T> html, string text = null)
        {
            return html.Awe()
                .Button()
                .Text(text ?? BtnContSpan(CancelIcon()))
                .CssClass("o-glcanb awe-nonselect o-gl o-glbtn o-btn-act o-icoc").ToString();
        }

        public static string InlineDeleteFormatForGrid<T>(
            this IHtmlHelper<T> html,
            string gridId,
            string key = "Id",
            bool nofocus = false,
            string cancelText = null,
            string deleteContent = null)
        {
            var popupName = html.GetPopupName("delete", gridId);

            return DeleteFormat(popupName, key, btnClass: "o-glh", nofocus: nofocus, deleteContent: deleteContent) +
                   html.InlineCancelBtn(cancelText);
        }

        public static IHtmlContent InlineCreateButtonForGrid<T>(this IHtmlHelper<T> html, string gridId, object parameters = null, string text = "Create")
        {
            gridId = html.Awe().GetContextPrefix() + gridId;
            //var parms = JsonConvert.SerializeObject(parameters);

            var parms = AUtil.JsonEncode(parameters);

            return html.Awe().Button(new ButtonOpt
            {
                Text = text,
                CssClass = "o-btnf",
                OnClick = string.Format("$('#{0}').data('api')?.inlineCreate?.({1})", gridId, parms)
            });
        }

        public static IHtmlContent CreateButtonForGrid<T>(this IHtmlHelper<T> html, string gridId, object parameters = null, string text = "Create")
        {
            return html.Awe().Button(new ButtonOpt
            {
                Text = text,
                OnClick = html.Awe().OpenPopup(html.GetPopupName("create", gridId)).Params(parameters).ToString()
            });
        }

        public static string EditFormatForGrid<T>(
            this IHtmlHelper<T> html,
            string gridId,
            string key = "Id",
            bool setId = false,
            bool noFocus = false,
            int? height = null,
            string btnContent = null)
        {
            var popupName = html.GetPopupName("edit", gridId);

            var click = html.Awe().OpenPopup(popupName).Params(new { id = $".({key})" });
            if (height.HasValue)
            {
                click.Height(height.Value);
            }

            var button = html.Awe().Button()
                .CssClass("awe-nonselect editbtn o-btn-act o-icoc")
                .HtmlAttributes(new { aria_label = "edit" })
                .Text(btnContent ?? BtnContSpan(EditIcon()))
                .OnClick(click);

            var attrdict = new Dictionary<string, object>();

            if (setId)
            {
                attrdict.Add("id", $"gbtn{popupName}.{key}");
            }

            if (noFocus)
            {
                attrdict.Add("tabindex", "-1");
            }

            button.HtmlAttributes(attrdict);

            return button.ToString();
        }

        public static string DeleteFormatForGrid<T>(this IHtmlHelper<T> html, string gridId, string key = "Id", bool noFocus = false)
        {
            gridId = html.Awe().GetContextPrefix() + gridId;

            return DeleteFormatForGrid(gridId, key, noFocus);
        }

        public static string EditFormat(string popupName, string key = "Id", bool setId = false, bool nofocus = false)
        {
            var idattr = "";
            if (setId)
            {
                idattr = $"id = 'gbtn{popupName}.{key}'";
            }

            var tabindex = nofocus ? "tabindex = \"-1\"" : string.Empty;

            return string.Format("<button aria-label=\"edit\" type=\"button\" class=\"awe-btn awe-nonselect editbtn\" {3} {2}" +
                                 " onclick=\"awe.open('{0}', {{ params:{{ id: '.({1})' }} }}, event)\">{4}</button>",
                popupName, key, idattr, tabindex, editContent);
        }

        public static string DeleteFormat(string popupName, string key = "Id", string deleteContent = null, string btnClass = null, bool nofocus = false)
        {
            if (deleteContent == null)
            {
                deleteContent = BtnContSpan(DeleteIcon());
            }

            var tabindex = nofocus ? "tabindex = \"-1\"" : string.Empty;

            return string.Format("<button aria-label=\"delete\" type=\"button\" class=\"awe-btn awe-nonselect delbtn o-btn-act o-icoc {3}\"" +
                                 " {4} onclick=\"awe.open('{0}', {{ params:{{ id: '.({1})' }} }}, event)\">{2}</button>",
                popupName, key, deleteContent, btnClass, tabindex);
        }

        public static string EditIcon()
        {
            var res = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M12 3H5a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7""></path><path d=""M18.375 2.625a1 1 0 0 1 3 3l-9.013 9.014a2 2 0 0 1-.853.505l-2.873.84a.5.5 0 0 1-.62-.62l.84-2.873a2 2 0 0 1 .506-.852z""></path></svg>";
            return res;
        }

        public static string DeleteIcon()
        {
            var trash = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M3 6h18""></path><path d=""M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6""></path><path d=""M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2""></path></svg>";
            return trash;
        }

        public static string SaveIcon()
        {
            var res = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round""><path d=""M20 6 9 17l-5-5""></path></svg>";
            return res;
        }

        public static string CancelIcon()
        {
            var res = @"<svg viewBox=""0 0 24 24"" width=""24"" height=""24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
  <circle cx=""12"" cy=""12"" r=""9"" stroke=""currentColor"" stroke-width=""2"" />
  <path d=""M6 18L18 6"" stroke=""currentColor"" stroke-width=""2"" />
</svg>";
            return res;
        }

        public static string BtnContSpan(string content)
        {
            return "<span class=\"o-btn-cont\">" + content + "</span>";
        }

        public static string InlineEditFormat(bool nofocus = false)
        {
            var tabindex = nofocus ? "tabindex = \"-1\"" : string.Empty;

            return string.Format("<button type=\"button\" class=\"awe-btn o-gledtb awe-nonselect o-glh o-glbtn o-btn-act o-icoc\" {0} ><span class=\"o-btn-cont\">" + EditIcon() + "</span></button>" +
                                 "<button type=\"button\" class=\"awe-btn o-glsvb awe-nonselect o-gl o-glbtn o-btn-act o-icoc\"><span class=\"o-btn-cont\">" + SaveIcon() + "</span></button>", tabindex);
        }

        public static string EditFormatForGrid(string gridId, string key = "Id", bool setId = false, bool nofocus = false)
        {
            return EditFormat("edit" + gridId, key, setId, nofocus);
        }

        public static string DeleteFormatForGrid(string gridId, string key = "Id", bool nofocus = false)
        {
            return DeleteFormat("delete" + gridId, key, null, null, nofocus);
        }

        public static Column EditDelNestColumn<T>(this IHtmlHelper<T> html)
        {
            return new Column
            {
                ClientFormat = Div("o-btnPnl", html.EditGridNestFormat() + html.DeleteGridNestFormat()),
                Width = EditDeleteColumnWidth
            };
        }

        public static string EditGridNestFormat<T>(this IHtmlHelper<T> html)
        {
            return html.Awe().Button().CssClass("awe-btn editnst o-btn-act o-icoc").Text(BtnContSpan(EditIcon())).ToString();
        }

        public static string DeleteGridNestFormat<T>(this IHtmlHelper<T> html)
        {
            return html.Awe().Button().CssClass("awe-btn delnst o-btn-act o-icoc").Text(BtnContSpan(DeleteIcon())).ToString();
        }

        public static string AddChildFormat(string gridId)
        {
            return "<button type='button' class='awe-btn awe-nonselect' onclick=\"awe.open('create" + gridId + "', { params:{ parentId: '.(Id)' } })\">add child</button>";
        }

        public static string MoveBtn()
        {
            return "<button type=\"button\" class=\"awe-movebtn awe-btn\" tabindex=\"-1\">" + AwesomeSettings.MultiLookup.MoveIco + "</button>";
        }

        public static Column EditDelColumn<T>(this IHtmlHelper<T> html, string gridId, bool noFocus = false)
        {
            return new Column
            {
                ClientFormat = Div("o-btnPnl", html.EditFormatForGrid(gridId, noFocus: noFocus) + html.DeleteFormatForGrid(gridId, noFocus: noFocus)),
                Width = EditDeleteColumnWidth
            };
        }

        public static Column InlEditDelColumn<T>(this IHtmlHelper<T> html, string gridId)
        {
            return new Column
            {
                ClientFormat = Div("o-btnPnl", InlineEditFormat() + html.InlineDeleteFormatForGrid(gridId)),
                Width = EditDeleteColumnWidth
            };
        }

        public static string Div(string cssClass, string content)
        {
            var htmlAttr = string.Empty;
            if (cssClass != null)
            {
                htmlAttr = " class=\"" + cssClass + "\" ";
            }

            return "<div" + htmlAttr + ">" + content + "</div>";
        }

        public static Column EditColumnForGrid<T>(this IHtmlHelper<T> html, string gridId, string btnContent = null)
        {
            return new Column { ClientFormat = html.EditFormatForGrid(gridId, btnContent: btnContent), Width = EditBtnWidth }.Mod(o => o.Nohide());
        }

        public static Column DeleteColumnForGrid<T>(this IHtmlHelper<T> html, string gridId)
        {
            return new Column { ClientFormat = html.DeleteFormatForGrid(gridId), Width = DeleteBtnWidth }.Mod(o => o.Nohide());
        }

        public static Column InlEditColumn<T>(this IHtmlHelper<T> html)
        {
            return new Column { ClientFormat = InlineEditFormat(), Width = EditBtnWidth }.Mod(o => o.Nohide());
        }

        public static Column InlDeleteColumn<T>(this IHtmlHelper<T> html, string gridId)
        {
            return new Column { ClientFormat = html.InlineDeleteFormatForGrid(gridId), Width = DeleteBtnWidth }.Mod(o => o.Nohide());
        }

        public static Column InlDeleteAlwaysColumn<T>(this IHtmlHelper<T> html, string gridId)
        {
            var popupName = html.GetPopupName("delete", gridId);

            return new Column
            {
                ClientFormat = DeleteFormat(popupName, "Id"),
                Width = DeleteBtnWidth
            }
            .Mod(o => o.Nohide());
        }

        public static Column InlCancelColumn<T>(this IHtmlHelper<T> html)
        {
            return new Column { ClientFormat = html.InlineCancelBtn(), Width = DeleteBtnWidth }.Mod(o => o.Nohide());
        }
    }
}