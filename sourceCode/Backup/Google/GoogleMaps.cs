using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Google
{
    [DefaultProperty("AppKey")]
    [ToolboxData("<{0}:GoogleMaps runat=server></{0}:GoogleMaps>")]
    public class GoogleMaps : WebControl
    {
        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        public string AppKey
        {
            get
            {
                if (ViewState["AppKey"] != null)
                    return (string)ViewState["AppKey"];
                return string.Empty;
            }
            set
            {
                ViewState["AppKey"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        public double Long
        {
            get
            {
                if (ViewState["Long"] != null)
                    return (double)ViewState["Long"];
                return 0;
            }
            set
            {
                ViewState["Long"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        public double Lat
        {
            get
            {
                if (ViewState["Lat"] != null)
                    return (double)ViewState["Lat"];
                return 0;
            }
            set
            {
                ViewState["Lat"] = value;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("500px")]
        public override Unit Width
        {
            get
            {
                if (ViewState["Width"] != null)
                    return (Unit)ViewState["Width"];
                return 0;
            }
            set
            {
                ViewState["Width"] = value;
            }
        }

        [Bindable(true)]
        [Category("Layout")]
        [DefaultValue("500px")]
        public override Unit Height
        {
            get
            {
                if (ViewState["Height"] != null)
                    return (Unit)ViewState["Height"];
                return 0;
            }
            set
            {
                ViewState["Height"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("5")]
        public int Zoom
        {
            get
            {
                if (ViewState["Zoom"] != null)
                    return (int)ViewState["Zoom"];
                return 0;
            }
            set
            {
                ViewState["Zoom"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        public string KmlFile
        {
            get
            {
                if (ViewState["KmlFile"] != null)
                    return (string)ViewState["KmlFile"];
                return string.Empty;
            }
            set
            {
                ViewState["KmlFile"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            var divTag = "<div id='map_canvas' style='width: " + Width + "; height: " + Height + "'></div>";
            output.Write(divTag);
            var jsGMapSrc =
                "<script src='http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true_or_false&amp;key=" +
                AppKey + "'type='text/javascript'></script>";


            //TODO:  Find the best place to place this javascript
            Page.ClientScript.RegisterStartupScript(GetType(), "jsGMapSrc", jsGMapSrc);
            var jsInitializae = "<script language='javascript'>function initialize() {";
            jsInitializae += "var map = new GMap2(document.getElementById('map_canvas'));";
            jsInitializae += "var point = new GLatLng(" + Lat + ", " + Long + ");";
            jsInitializae += "map.setCenter(point, " + Zoom + ");";
            jsInitializae += "map.setUIToDefault();";

            if(!(string.IsNullOrEmpty(KmlFile)))
            {
                jsInitializae += "geoXml = new GGeoXml('" + KmlFile + "');";
                jsInitializae += "map.addOverlay(geoXml);";
            }

            jsInitializae += "var ui = new GMapUIOptions();";
            jsInitializae += "ui.maptypes = { hybrid: true };";
            jsInitializae += "ui.zoom = { scrollwheel: true };";
            jsInitializae += "ui.controls = { largemapcontrol3d: true };";
            jsInitializae += "map.setUI(ui);}</script>";
            Page.ClientScript.RegisterStartupScript(GetType(), "GMap2Init", jsInitializae);
            if (!Page.ClientScript.IsStartupScriptRegistered("onload"))
            {
                Page.ClientScript.RegisterStartupScript
                    (GetType(), "onload", "initialize();", true);
            }
        }
    }
}
