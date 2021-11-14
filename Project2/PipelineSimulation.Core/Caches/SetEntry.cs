using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Caches {
	public class SetEntry {

		public int Tag;
		public ushort Data;
		public int LRU;

		public SetEntry(int tag, ushort data) {
			Tag = tag;
			Data = data;
			LRU = 0;
		}

	}
}
