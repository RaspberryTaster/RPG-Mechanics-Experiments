using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Units
{
	public class Team : IHave_Initative
	{
		public int team;
		public List<Unit> team_Units = new List<Unit>();
		public int Highest_Initative { get { return team_Units[0] != null ? team_Units[0].Initative : 0; } }
		public int Unit_Count { get { return team_Units != null ? team_Units.Count : 0; } }

		public int Initative { get => Highest_Initative; }

		public Team(int team)
		{
			this.team = team;
		}

		public Team(int team, List<Unit> team_Units)
		{
			this.team = team;
			this.team_Units = team_Units;
		}

		public void Add_Units_Master(ref List<Unit> units)
		{
			Add_Units(ref units);
			Arrange_Units();
		}
		public void Add_Units(ref List<Unit> units)
		{
			int count = units.Count;
			for (int i = 0; i < count; i++)
			{
				if (units[i].Team == team && !team_Units.Contains(units[i]))
				{
					team_Units.Add(units[i]);
				}
			}
		}

		private void Arrange_Units()
		{
			Arrange_By_Initative unit_Comparer = new Arrange_By_Initative();
			team_Units.Sort(unit_Comparer);
			team_Units.Reverse();
		}
		public void Subract_From_Unit_List(ref List<Unit> units)
		{
			List<Unit> result = units.Except(team_Units).ToList();
			units = result;
		}
	}
}
