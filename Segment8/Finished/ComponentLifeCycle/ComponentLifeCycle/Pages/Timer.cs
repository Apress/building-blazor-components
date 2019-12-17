using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentLifeCycle.Pages
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

      }
    }

    private System.Threading.Timer timer = null;

    public override Task SetParametersAsync(ParameterView parameters)
    {
      if( parameters.TryGetValue(nameof(TimeInSeconds), out double time))
      {
        if( time <= 0)
        {
          throw new InvalidProgramException("TimeInSeconds should be positive");
        }
      }
      return base.SetParametersAsync(parameters);
    }

    protected override void OnParametersSet()
    {
      base.OnParametersSet();

      if (Active)
      {
        this.timer ??= new System.Threading.Timer(
          callback: (_) => this.InvokeAsync(() => Tick.InvokeAsync(null)),
          state: null,
          dueTime: TimeSpan.FromSeconds(TimeInSeconds),
          period: System.Threading.Timeout.InfiniteTimeSpan
          );
      }
      else
      {
        this.timer?.Dispose();
        this.timer = null;
      }
    }

    protected override bool ShouldRender() 
      => base.ShouldRender();

    protected override void OnAfterRender(bool firstRender) 
      => base.OnAfterRender(firstRender);

    public void Dispose() 
      => this.timer?.Dispose();
  }
}
