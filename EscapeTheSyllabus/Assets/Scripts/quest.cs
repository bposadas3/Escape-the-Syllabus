using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class quest : ScriptableObject
{
	private string qname = "New Quest";
	private string qdescription = "Description";


	public void setName (string qn) {
		qname = qn;
	}

	public void setDescription (string qdes) {
		qdescription = qdes;
	}

	public string getName() {
		return qname;
	}

	public string getDescription() {
		return qdescription;
	}
}
