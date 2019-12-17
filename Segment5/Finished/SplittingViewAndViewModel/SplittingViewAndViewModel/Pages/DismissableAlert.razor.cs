using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplittingViewAndViewModel.Pages
{
  public partial class DismissableAlert
  {
    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void Dismiss() => this.Show = false;
  }
}
