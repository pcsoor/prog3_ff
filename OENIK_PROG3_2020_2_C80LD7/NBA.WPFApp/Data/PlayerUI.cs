using GalaSoft.MvvmLight;
using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.WPFApp.Data
{
    public class PlayerUI : ObservableObject
    {
        string name;
        DateTime birth;
        int height;
        int weight;
        string post;
        int salary;
        int number;
        Teams team;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        public DateTime Birth
        {
            get { return birth; }
            set { Set(ref birth, value); }
        }

        public int Height
        {
            get { return height; }
            set { Set(ref height, value); }
        }

        public int Weight
        {
            get { return weight; }
            set { Set(ref weight, value); }
        }

        public string Post
        {
            get { return post; }
            set { Set(ref post, value); }
        }

        public int Salary
        {
            get { return salary; }
            set { Set(ref salary, value); }
        }

        public int Number
        {
            get { return number; }
            set { Set(ref number, value); }
        }

        public Teams Team
        {
            get { return team; }
            set { Set(ref team, value); }
        }

        public void CopyFrom(PlayerUI other)
        {
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
