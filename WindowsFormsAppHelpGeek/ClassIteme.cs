using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppHelpGeek
{
    public class ClassIteme : IEquatable<ClassIteme>
    {
        private int id;
        private string nom;

        public ClassIteme(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public bool Equals(ClassIteme other)
        {
            if ((this.id == other.id) && (this.nom == other.nom))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getId() { return id; }

        public string getNom() { return nom; }

        public override string ToString()
        {
            return this.nom;
        }

    }
}
