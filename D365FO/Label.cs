using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelTranslator
{
    public class Label : IEquatable<Label>
    {
        public string LabelId { get; private set; }
        public string LabelText { get; set; }
        public string Comment { get; set; }

        public Label(string labelId)
        {
            LabelId = labelId;
        }

        public override bool Equals(object obj) => Equals(obj as Label);

        public bool Equals(Label l)
        {
            if (l is null)
                return false;

            if (ReferenceEquals(this, l))
                return true;

            if (GetType() != l.GetType())
                return false;

            return (LabelId == l.LabelId);
        }

        public override int GetHashCode() => (LabelId).GetHashCode();

        public static bool operator ==(Label lhs, Label rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Label lhs, Label rhs) => !(lhs == rhs);
    }
}
