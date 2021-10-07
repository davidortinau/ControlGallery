﻿using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGallery.Models
{
    public class NavItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public Type Destination { get; set; }
        public string Description { get; set; }

        public Command NavigateTo { private set; get; }

        public NavItem()
        {
            NavigateTo = new Command(
                async () =>
                {
                    await Shell.Current.GoToAsync(Destination.Name);
                });
        }
    }
}
