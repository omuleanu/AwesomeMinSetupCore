using Microsoft.AspNetCore.Html;

namespace MinSetupCore.Utils.Awesome
{
    public class MyAweIcons
    {
        public static string DetailNstBtn(string prop)
        {
            return "<div class='detailnst'>" + CaretIcoStr + " .(" + prop + ")</div>";
        }

        public static string CaretIcoStr = "<svg class=\"awe-cbc awe-nonselect\" fill=\"currentColor\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\"><path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M7.47 9.47a.75.75 0 0 1 1.06 0L12 12.94l3.47-3.47a.75.75 0 1 1 1.06 1.06l-3.646 3.647a1.25 1.25 0 0 1-1.768 0L7.47 10.53a.75.75 0 0 1 0-1.06Z\"></path></svg>";

        public static IHtmlContent ZoomIco() => new HtmlString("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><circle cx=\"11\" cy=\"11\" r=\"8\" /><path d=\"m21 21-4.3-4.3\" /></svg>");

        public static IHtmlContent LeafIco()
        {
            return new HtmlString("<div class=\"o-icoc o-flex\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"20\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"M11 20A7 7 0 0 1 9.8 6.1C15.5 5 17 4.48 19 2c1 2 2 4.18 2 8 0 5.5-4.78 10-10 10Z\" /><path d=\"M2 21c0-3 1.85-5.36 5.08-6C9.5 14.52 12 13 13 12\" /></svg></div>");
        }

        public static IHtmlContent SaveIco()
        {
            return new HtmlString("<div class=\"o-icoc o-flex\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"20\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"M15.2 3a2 2 0 0 1 1.4.6l3.8 3.8a2 2 0 0 1 .6 1.4V19a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2z\"/><path d=\"M17 21v-7a1 1 0 0 0-1-1H8a1 1 0 0 0-1 1v7\"/><path d=\"M7 3v4a1 1 0 0 0 1 1h7\"/></svg></div>");
        }

        public static IHtmlContent ReloadIco()
        {
            return new HtmlString("<i class=\"o-icoc awe-reload-ico\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-refresh-ccw h-4 w-4 shrink-0\"><path d=\"M21 12a9 9 0 0 0-9-9 9.75 9.75 0 0 0-6.74 2.74L3 8\"></path><path d=\"M3 3v5h5\"></path><path d=\"M3 12a9 9 0 0 0 9 9 9.75 9.75 0 0 0 6.74-2.74L21 16\"></path><path d=\"M16 16h5v5\"></path></svg></i>");
        }

        public static IHtmlContent CancelIco()
        {
            return new HtmlString("<div class=\"o-icoc o-flex\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"20\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><circle cx=\"12\" cy=\"12\" r=\"10\"/><path d=\"m15 9-6 6\"/><path d=\"m9 9 6 6\"/></svg></div>");
        }

        public static IHtmlContent PlusIco()
        {
            return new HtmlString("<div class=\"o-icoc o-flex\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"20\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><circle cx=\"12\" cy=\"12\" r=\"10\"/><path d=\"M8 12h8\"/><path d=\"M12 8v8\"/></svg></div>");
        }

        public static IHtmlContent ChevronIco(string cssClass = null)
        {
            return new HtmlString("<div class=\"o-icoc o-flexc " + cssClass + "\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"1.75\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m6 9 6 6 6-6\"></path></svg></div>");
        }

        public static IHtmlContent PanelLeftIco(string cssClass = null)
        {
            return new HtmlString("<div class=\"o-icoc o-flexc " + cssClass + "\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"20\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><rect width=\"18\" height=\"18\" x=\"3\" y=\"3\" rx=\"2\"/><path d=\"M9 3v18\"/><path d=\"m14 9 3 3-3 3\"/></svg></div>");
        }
    }
}