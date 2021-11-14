using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Caches {
	public abstract class Cache {

		public int Associativity;
		public Dictionary<int, List<SetEntry>> Sets;

		public Cache(int assoc) {
			Associativity = assoc;
			Sets = new Dictionary<int, List<SetEntry>>();
		}
		
		// Determines if the cache contains the requested data. Assumes that the data will be used in
		// another method immediately after, and sets LRU values. Returns a boolean stating whether or 
		// not the data can be accessed in this cache.
		public bool CanAccess(int Index, int Tag) {
			bool canAccess = false;

			//is cached?
			//check index
			if (Sets.ContainsKey(Index)) {
				//check tag
				for (int i = 0; i < Sets[Index].Count; i++) {
					if (Sets[Index][i].Tag == Tag) { //CASE: We have a cache hit
						canAccess = true;
						//set LRU values
						for (int j = 0; j < Sets[Index].Count; j++) {
							Sets[Index][j].LRU++;
						}
						Sets[Index][i].LRU = 0;
					}
				}
			}

			//TODO: Include Valid and Access bits // This is a TODO from OS that never got done lol

			return canAccess;
		}

		// Returns the requested value. 
		public int Get(int Index, int Tag) {

			return -1; //TODO // Apparently I never simulated data flow in my OS project either
		}

		// Inserts data into the cache
		void Insert(int Index, int Tag, ushort Data) {
			//first, determine if there is already a set for that index.
			if (Sets.ContainsKey(Index)) {
				//if not create a set.
				Sets[Index] = new List<SetEntry>();
				SetEntry temp = new SetEntry(Tag, Data);
				Sets[Index].Add(temp);
			}
			//Find the LRU = Associativity after incrementing and evict that entry before adding the new one.
			else {
				for (int i = 0; i < Sets[Index].Count; i++) {
					Sets[Index][i].LRU++;
					if (Sets[Index][i].LRU == Associativity) {
						Evict(Index, i);
					}
				}

				SetEntry temp = new SetEntry(Tag, Data);
				Sets[Index].Add(temp);
			}

			return;
		}

		// Evicts data from the cache
		public void Evict(int Index, int i) {
			Sets[Index].Remove(Sets[Index][i]);
		}

	}
}
