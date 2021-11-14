using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Caches {
	public class SetEntry {

		public int Tag;
		public int Data;
		public int LRU;

		public SetEntry(int tag, int data) {
			Tag = tag;
			Data = data;
			LRU = 0;
		}

	}
}
