using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class ZIndexFactory
    {
        public static ZIndex CreateZIndex(ZIndexConfig config)
        {
            return new ZIndex
            {
                MobileStepper = config?.MobileStepper ?? 1000,

                SpeedDial = config?.SpeedDial ?? 1050,

                AppBar = config?.AppBar ?? 1100,

                Drawer = config?.Drawer ?? 1200,

                Modal = config?.Modal ?? 1300,

                Snackbar = config?.Snackbar ?? 1400,

                Tooltip = config?.Tooltip ?? 1500
            };
        }
    }
}