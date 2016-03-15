using System;
using System.Reflection;
using ColossalFramework;
using ICities;
using Transit.Addon.TM.AI;
using UnityEngine;

namespace Transit.Addon.TM {
    public sealed class ThreadingExtension : ThreadingExtensionBase {
        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta) {
            base.OnUpdate(realTimeDelta, simulationTimeDelta);
#if !TAM
			if (TrafficManagerModule.Instance == null || ToolsModifierControl.toolController == null || ToolsModifierControl.toolController == null || TrafficManagerModule.Instance.UI == null) {
                return;
            }

            if (ToolsModifierControl.toolController.CurrentTool != TrafficManagerModule.Instance.TrafficManagerTool && TrafficManagerModule.Instance.UI.IsVisible()) {
                TrafficManagerModule.Instance.UI.Close();
            }
			
            if (!TrafficManagerModule.Instance.NodeSimulationLoaded) {
                TrafficManagerModule.Instance.NodeSimulationLoaded = true;
                ToolsModifierControl.toolController.gameObject.AddComponent<CustomRoadAI>();
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                TrafficManagerModule.Instance.UI.Close();
            }
#endif
        }
    }
}
