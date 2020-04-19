﻿using UnityEngine;
using System;

/// <summary>
/// Перемещение объекта в пул при выходе из зоны видимости камеры
/// </summary>
public class PoolObject : MonoBehaviour
{
	[SerializeField]
	bool needEventOnReturningToPool = false;

	Pool parentPool = null;
	ObjectsController objectsController = null;

	public void setParentPool(Pool newParentPool)
	{
		if (newParentPool == null) Debug.LogError("Пул не инициализирован!");
		parentPool = newParentPool;

		objectsController = parentPool.GetComponent<ObjectsController>();
	}

    void OnBecameInvisible()
	{
		if (parentPool != null)
		{
			//Если игра не находится в состоянии Конеца Игры
			//Если игра не находится в состоянии Пауза
			if (!Statements.gameOver && !Statements.pause)
			{
				parentPool.addObject(this);
				if(needEventOnReturningToPool) objectsController.getObjectFromPool();
			}
		}
	}
}
