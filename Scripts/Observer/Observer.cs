﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongpn.Singleton;
using System;

namespace Dongpn.Observer
{
    public class Observer : Singleton<Observer>
    {

		Dictionary<int, Action<object>> manager = new Dictionary<int, Action<object>>();


		public void RegisterListener(int subjectID, Action<object> callback)
		{
			if(callback == null || subjectID < 0)
            {
				//callback null or subjectID not valid
				return;
            }

			if (manager.ContainsKey(subjectID))
			{
				manager[subjectID] += callback;
			}
			else
			{
				manager.Add(subjectID, null);
				manager[subjectID] += callback;
			}
		}

		public void PostEvent(int subjectID, object param = null)
		{
			if (!manager.ContainsKey(subjectID))
			{
				//dont has subject
				return;
			}


			var callbacks = manager[subjectID];
			if (callbacks != null)
			{
				callbacks(param);
			}
			else
			{
				//dont has any callback, remove subject
				manager.Remove(subjectID);
			}
		}

		public void RemoveListener(int subjectID, Action<object> callback)
		{
			if (callback == null || subjectID < 0)
			{
				//callback null or subjectID not valid
				return;
			}

			if (manager.ContainsKey(subjectID))
			{
				manager[subjectID] -= callback;
			}
			else
			{
				Debug.LogWarning("Remove action on not exist subject");
			}
		}

		public void ClearAllListener()
		{
			manager.Clear();
		}
	}
}

