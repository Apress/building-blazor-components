using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentInitialization.Pages
{
  public class Timer : ComponentBase, IDisposable
  {

    [Parameter]
    public double TimeInSeconds { get; set; }

    [Parameter]
    public EventCallback Tick { get; set; }

    private bool active;

    [Parameter]
    public bool Active
    {
      get => active;
      set { 
        active = value;

        if( Active )
        {
          this.timer ??= new System.Threading.Timer(
            callback: (_) => this.InvokeAsync(() => Tick.InvokeAsync(null)),
            state: null,
            dueTime: TimeSpan.FromSeconds(TimeInSeconds),
            period: System.Threading.Timeout.InfiniteTimeSpan
            );
        } else
        {
          this.timer?.Dispose();
          this.timer = null;
        }
      }
    }

    private System.Threading.Timer timer = null;

    public void Dispose() => timer?.Dispose();
  }
}
