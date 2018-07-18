﻿using Scripts.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Units
{
    [RequireComponent(typeof(Camera))]
    public class UnitSelecterController : MonoBehaviour
    {
        [SerializeField]
        private List<UnitController> selectedUnits;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var unit = hit.collider.GetComponent<UnitController>();
                    if (unit != null)
                    {
                        selectedUnits.Add(unit);
                        unit.SetSelection(true);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    foreach (var unit in selectedUnits)
                    {
                        unit.Move(hit.point + (hit.normal * VoxelWorldController._blockSize / 2f));
                    }
                }
            }
        }
    }
}