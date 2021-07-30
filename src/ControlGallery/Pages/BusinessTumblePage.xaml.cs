using System.Collections.Generic;

using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace LayoutLab
{
	public partial class BusinessTumblePage : ContentPage
	{
		public BusinessTumblePage ()
		{
			InitializeComponent ();
		}

		public override string ToString(){
			return this.Title;
		}
	}
}

