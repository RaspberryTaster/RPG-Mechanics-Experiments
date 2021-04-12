using Assets.Event_Managment.Runtimeset;
using Assets.Units;
using NaughtyAttributes;
using Raspberry.Events;
using Raspberry.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Battles
{
	[CreateAssetMenu(menuName = "Turnbased/ Battle/ Order Manager")]
	public class Battle_Order_Manager : ScriptableObject
	{
		public Unit_Runtime_Set unit_Runtime_Set;
		public Event_Broadcaster New_Round;
		public Event_Broadcaster New_Turn;
		[SerializeField] private List<Unit> unorderd_Units = new List<Unit>();
		public List<Unit> orderd_Units = new List<Unit>();
		public Rotating_Index<Unit> rotating_Index;
		public Unit Current_Unit { get => rotating_Index.Indexed_Item != null? rotating_Index.Indexed_Item : null; }
		private List<Team> teams = new List<Team>();
		public void OnEnable()
		{
			Initalize_Rotating_Index();
		}
		public void Awake()
		{
			Initalize_Rotating_Index();
		}
		[Button("Start", EButtonEnableMode.Always)]
		public void Start_Battle()
		{
			if(unit_Runtime_Set.Items == null || unit_Runtime_Set.Items.Count == 0)
			{
				Debug.LogWarning("No units in " + unit_Runtime_Set);
			}

			unorderd_Units = unit_Runtime_Set.Items;
			orderd_Units.Clear();
			teams.Clear();
			Create_Teams();
			Add_Units_To_Team();

			Order_Teams();
			Add_To_Orderd_Units();
			Initalize_Rotating_Index();
		}
		private void Initalize_Rotating_Index()
		{
			rotating_Index = new Rotating_Index<Unit>(orderd_Units);
		}

		[Button("Next", EButtonEnableMode.Always)]
		public void Next_Unit()
		{
			rotating_Index.Next();
			if(rotating_Index.Index == 0)
			{
				New_Round.Raise();
			}
			else
			{
				New_Turn.Raise();
			}	
		}

		[Button("Remove", EButtonEnableMode.Always)]
		public void Remove_CUrrent_Unit()
		{
			Unit target_Unit = Current_Unit;
			Remove_From_Queue(target_Unit);
			if (rotating_Index.Index == 0)
			{
				New_Round.Raise();
			}
			else
			{
				New_Turn.Raise();
			}
			//Next_Unit();
		}

		/*
		private void Remove_Unit(Unit target_Unit)
		{
			rotating_Index.Remove(target_Unit);
			unit_Runtime_Set.Remove(target_Unit);

		}
		*/
		[Button("Back", EButtonEnableMode.Always)]
		public void Previous_Unit()
		{
			rotating_Index.Back();
		}

		public void Create_Teams()
		{
			int count = unorderd_Units.Count;
			for (int i = 0; i < count; i++)
			{
				Unit unit = unorderd_Units[i];
				if (unit == null) return;
				if (!Team_Already_Exists(unit.Team))
				{
					Team team = new Team(unit.Team);
					teams.Add(team);
				}
			}

		}
		public bool Team_Already_Exists(int unit_Team)
		{
			int count = teams.Count;
			for (int i = 0; i < count; i++)
			{
				if (teams[i].team == unit_Team)
				{
					return true;
				}
			}
			return false;
		}

		public void Add_Units_To_Team()
		{
			int count = teams.Count;
			for (int i = 0; i < count; i++)
			{
				teams[i].Add_Units_Master(ref unorderd_Units);
			}
			for (int i = 0; i < count; i++)
			{
				teams[i].Subract_From_Unit_List(ref unorderd_Units);
			}
		}
		public void Order_Teams()
		{
			Arrange_By_Initative queue_Sort_By_Initative = new Arrange_By_Initative();
			teams.Sort(queue_Sort_By_Initative);
			teams.Reverse();
		}

		public void Add_To_Orderd_Units()
		{
			if (teams == null || teams.Count == 0) return;
			List<int> unit_Counts = new List<int>();

			for (int i = 0; i < teams.Count; i++)
			{
				unit_Counts.Add(teams[i].Unit_Count);
			}

			int largest_Unit_Count = unit_Counts.Max();

			for (int i = 0; i < largest_Unit_Count; i++)
			{
				foreach (Team team in teams)
				{
					List<Unit> team_Units = team.team_Units;
					if (i < team_Units.Count)
					{
						if (orderd_Units.Contains(team_Units[i])) return;
						orderd_Units.Add(team_Units[i]);
					}
				}

			}
		}
		public void Remove_From_Queue(Unit unit)
		{
			Debug.Log(unit + " has been removed from queue!");
			Remove_From_Orderd_Units(unit);
			Remove_From_Unorderd_Units(unit);
			Remove_From_Team(unit);
		}

		private void Remove_From_Orderd_Units(Unit unit)
		{
			if (orderd_Units.Contains(unit))
			{
				orderd_Units.Remove(unit);
			}
		}

		private void Remove_From_Unorderd_Units(Unit unit)
		{
			if (unorderd_Units.Contains(unit))
			{
				unorderd_Units.Remove(unit);
			}
		}

		private void Remove_From_Team(Unit unit)
		{
			for (int i = 0; i < teams.Count; i++)
			{
				if (teams[i].team_Units.Contains(unit))
				{
					teams[i].team_Units.Remove(unit);
					if (teams[i].team_Units.Count == 0)
					{
						teams.Remove(teams[i]);
					}
				}
			}
		}

		public void Reset_Queue()
		{
			unorderd_Units.Clear();
			orderd_Units.Clear();
			teams.Clear();
		}

		public void Modify_Unit_Turn_Order(Unit unit, int order_Modifier)
		{
			if (!unit_Runtime_Set.Items.Contains(unit)) return;
			var unit_In_Question = unit;
			int unit_Index = unit_Runtime_Set.Items.IndexOf(unit);
			int new_Index = unit_Index + order_Modifier;
			unit_Runtime_Set.Items.Remove(unit);
			new_Index = Mathf.Clamp(new_Index, 0, unit_Runtime_Set.Items.Count);
			unit_Runtime_Set.Items.Insert(new_Index, unit_In_Question);
		}
		public void Set_Unit_Turn_Order(Unit unit, int set_Turn_order)
		{
			if (!unit_Runtime_Set.Items.Contains(unit)) return;
			unit_Runtime_Set.Items.Remove(unit);
			unit_Runtime_Set.Items.Insert(set_Turn_order, unit);
		}
	}
}
