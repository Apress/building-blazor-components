using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace InputDigitsComponentLib
{
  internal class DigitCollection
  {
    class InputTuple
    {
      public InputDigit Input { get; set; }

      public int Pos { get; set; }

      public bool HasFocus { get; set; }
    }

    private List<InputTuple> inputs = new List<InputTuple>();

    public event EventHandler InputsComplete;

    public void Add(InputDigit input, int pos, bool hasFocus)
    {
      inputs.Add(new InputTuple { Input = input, Pos = pos, HasFocus = hasFocus });
    }

    public int Count => inputs.Count;

    public void ReInitInputs(string digits)
    {
      Console.WriteLine(nameof(ReInitInputs));
      foreach (var tuple in inputs)
      {
        tuple.Input.SetDigitFromParent(digits.AtPos(tuple.Pos));
      }
    }

    public async Task FocusAsync()
    {
      foreach (var tuple in inputs)
      {
        if (tuple.HasFocus)
        {
          await tuple.Input.FocusAsync();
        }
      }
    }

    public async Task MoveFocusToNextAsync(int currentPos)
    {
      Console.WriteLine($"MoveFocusToNextAsync for {currentPos}");
      foreach (var tuple in inputs)
      {
        if (tuple.HasFocus)
        {
          await tuple.Input.BlurAsync();
        }
        tuple.HasFocus = (tuple.Pos == currentPos + 1);
        Console.WriteLine($"Tuple {tuple.Pos} {tuple.HasFocus}");
        if (tuple.HasFocus)
        {
          await tuple.Input.FocusAsync();
        }
      }
      // If no input has focus, then input is complete
      if (!inputs.Any(tuple => tuple.HasFocus))
      {
        Console.WriteLine("Inputs complete");
        InputsComplete?.Invoke(this, EventArgs.Empty);
      }
    }

    public async Task ResetAsync()
      => await MoveFocusToNextAsync(-1);
  }
}
