using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Unicab.App.CM
{
    public class SortModel : BindableObject
    {
        public SortModel()
        {
        }

        // you can customize your sorting algorithim to however you want it to work.
        public Func<string, ICollection<string>, ICollection<string>> SortingAlgorithm { get; } =
            (text, values) => values
                .Where(x => x.ToLower().Contains(text.ToLower()))
                .OrderBy(x => x)
                .ToList();

    }
}
