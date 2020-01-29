using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Algorithms
{
    public interface IShareEventHandler
    {
        void Share(object sender, EventArgs e);
    }
}
