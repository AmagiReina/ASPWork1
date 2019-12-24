using Homework1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Utils
{
    public static class EditHelper
    {
        public static MvcHtmlString ListItems(this HtmlHelper html, List<Genre> items)
        {
            TagBuilder list = new TagBuilder("ul");

            foreach (Genre item in items)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(item.GenreName);
                list.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(list.ToString());
        }
    }
}