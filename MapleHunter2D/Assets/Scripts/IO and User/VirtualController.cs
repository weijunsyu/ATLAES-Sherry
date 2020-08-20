// GENERATED AUTOMATICALLY FROM 'Assets/IO/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VirtualController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VirtualController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Mouse And Keyboard"",
            ""id"": ""c0085b57-853b-41aa-b461-8523d633ee09"",
            ""actions"": [
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""1526bed1-988b-4256-af3c-a0202b181062"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""51b396bd-c4b8-45dc-a480-6c975d99a18a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3b9722dd-2873-4d81-a54a-ff3e799e4c2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""e86e1415-ea82-4d98-9653-fff66d018a59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""94f93807-ef7e-490b-aa43-7e37cc87f803"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""d56f6e48-9f9e-428b-ad42-ff32a3e866be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defend"",
                    ""type"": ""Button"",
                    ""id"": ""f7a48f45-c224-4b9c-a24d-ed356c7916bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9022af75-6ac2-4072-82ca-68494c738d3c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""3f597fe4-f510-457c-af9c-aabc138e32a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""06159f99-66a1-4437-a80a-78403d579504"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Utility 1"",
                    ""type"": ""Button"",
                    ""id"": ""ba1bbb04-afb9-4bfc-bad8-0341aa9298ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Utility 2"",
                    ""type"": ""Button"",
                    ""id"": ""c87ceb0d-db06-4763-a3bc-fa6f298a51f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""37bc4ad7-00ec-41f2-a384-f51507ad8ef1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause Game"",
                    ""type"": ""Button"",
                    ""id"": ""83af9e11-ec3c-4e27-8aab-c777ece51fc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""af09eaf9-fcb0-40b0-8226-f2657058b95f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e7f92bc-15a6-4614-af06-bb7d5c4f3047"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7441e45a-046f-45e7-be42-7de9e6b52cbd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d02a5f16-7c7a-4844-b7b8-2d908dacec21"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82e129e2-7912-4284-a8bb-312d28259c67"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58193b55-51d4-4c28-a990-6b56e90ae604"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18686145-fe24-4520-9561-fd8e93475766"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Utility 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4b738de-74e4-422d-b019-420af81b6a7d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Utility 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fafcdcc-3e5f-49f9-803d-d3f3b16c3381"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbcaabe1-b041-4fab-8cef-f3e3f52fba40"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2af8da0b-99b9-4981-a6d3-44e0fac20e82"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2da53ebc-c5f2-4453-96fa-522a3c80ac62"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d52a08cd-0ef7-41e7-a48e-872bdab3bfe6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b29dd50-2ece-44bf-8c21-48676d334c8c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41856f60-dba9-4c32-8e8e-692b82175c2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad Controller"",
            ""id"": ""f6af7798-bb87-4ea6-828b-ce5db6c1a53d"",
            ""actions"": [
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""aafbca96-3060-4240-bea8-4e7b0638adae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""bb2d0440-2532-47a2-9e54-b8cf5c4ac82c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""60423050-b018-4cf1-b425-fcf3ab2bf449"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""1a288bd6-2270-4a84-8fd9-4ba809654aa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""3ec741ca-31f7-4cdc-81d3-be9e0591b4f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""13b474f6-bbbf-48c2-83a4-35e391309493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defend"",
                    ""type"": ""Button"",
                    ""id"": ""8e84932e-89d3-4049-a1bc-bad3459b0084"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eec16e37-eb56-48ab-9d69-bc50f457d234"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hold Secondary Aim Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4043881a-5eb7-4839-ae21-73fd1bc1e2f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""a0d5ee3c-805b-4c54-a18d-c3e90b31a4e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""65926634-e774-47b1-aaa8-7ae6becd8d5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Utility 1"",
                    ""type"": ""Button"",
                    ""id"": ""8fdcff05-5ab1-4b15-8f8a-f65212000e39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Utility 2"",
                    ""type"": ""Button"",
                    ""id"": ""2035ae6e-9a83-49f2-8d33-417b1c5b6d6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""668b8832-8a40-426e-9e6c-7258055ea925"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause Game"",
                    ""type"": ""Button"",
                    ""id"": ""23eafbdd-e1cf-49a6-b2ef-0affa98f5200"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fe6579b0-1a6c-494d-bc18-4a724b4ab10e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6728c6-8d52-4e7a-b38e-32ae99d2918e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8929602f-f171-4219-8819-520c33379a5a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd110122-0c4e-4b8b-afdb-b9799cb75e5d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b1c13f3-4cb6-494a-ae07-d2d14b24b0bb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecb7c0d2-8a83-4fb0-9f08-f91f6c62af91"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12ddeacc-e288-4fed-9a10-e7c8f705f5ae"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73c06646-9881-4e0e-963c-83849c6fa9ba"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be1d793f-21aa-4bdb-b903-c386069c8963"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Utility 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50e28cbf-55b0-4994-9e16-c04f2e8ebf48"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Utility 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c7753a8-72a8-43a7-9e37-471e031b7504"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Aim Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd6d286e-122a-4320-a106-c4ba9a856222"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd281ff8-77cb-4cc1-953c-317f753fa518"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""609272f5-03b0-4ac9-81c3-ac7872b4c984"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ee65ee9-7e44-4231-9097-dcf6e3239edd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd889d7-4f2b-4d60-8623-39c0165da38f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aaf38e0-4ed4-4a6a-bc96-770eca2ef733"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Hold Secondary Aim Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d306634-0919-42dc-a510-791398a6e3c8"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a53c83eb-8d5d-46fd-8463-4dcc9ab9e71d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause Menu"",
            ""id"": ""2f3a2a0e-56f5-4cd2-b775-07fdb1e0b59d"",
            ""actions"": [
                {
                    ""name"": ""Pause Game"",
                    ""type"": ""Button"",
                    ""id"": ""255b00d7-d511-472b-98d8-e088a0e6b8f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""91a23fc7-1cc8-4716-840f-2d5c9853e319"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd3ef7b-913f-40e2-8071-dd64edac5005"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""0e0f8307-5027-4284-9c19-3d55874fb10b"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""a8d4aaf0-0338-4e31-ab19-06c9b665bdab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f38e313d-80a9-49b5-9dff-a099268053f1"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""983b8f64-b298-46f5-81d2-988e6ca4c1ed"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9516a723-e8d9-4f80-a83a-03eaae75ae4c"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard+Mouse"",
            ""bindingGroup"": ""Keyboard+Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Mouse And Keyboard
        m_MouseAndKeyboard = asset.FindActionMap("Mouse And Keyboard", throwIfNotFound: true);
        m_MouseAndKeyboard_MoveRight = m_MouseAndKeyboard.FindAction("Move Right", throwIfNotFound: true);
        m_MouseAndKeyboard_MoveLeft = m_MouseAndKeyboard.FindAction("Move Left", throwIfNotFound: true);
        m_MouseAndKeyboard_Jump = m_MouseAndKeyboard.FindAction("Jump", throwIfNotFound: true);
        m_MouseAndKeyboard_Crouch = m_MouseAndKeyboard.FindAction("Crouch", throwIfNotFound: true);
        m_MouseAndKeyboard_Up = m_MouseAndKeyboard.FindAction("Up", throwIfNotFound: true);
        m_MouseAndKeyboard_Dash = m_MouseAndKeyboard.FindAction("Dash", throwIfNotFound: true);
        m_MouseAndKeyboard_Defend = m_MouseAndKeyboard.FindAction("Defend", throwIfNotFound: true);
        m_MouseAndKeyboard_Aim = m_MouseAndKeyboard.FindAction("Aim", throwIfNotFound: true);
        m_MouseAndKeyboard_Primary = m_MouseAndKeyboard.FindAction("Primary", throwIfNotFound: true);
        m_MouseAndKeyboard_Secondary = m_MouseAndKeyboard.FindAction("Secondary", throwIfNotFound: true);
        m_MouseAndKeyboard_Utility1 = m_MouseAndKeyboard.FindAction("Utility 1", throwIfNotFound: true);
        m_MouseAndKeyboard_Utility2 = m_MouseAndKeyboard.FindAction("Utility 2", throwIfNotFound: true);
        m_MouseAndKeyboard_Inventory = m_MouseAndKeyboard.FindAction("Inventory", throwIfNotFound: true);
        m_MouseAndKeyboard_PauseGame = m_MouseAndKeyboard.FindAction("Pause Game", throwIfNotFound: true);
        // Gamepad Controller
        m_GamepadController = asset.FindActionMap("Gamepad Controller", throwIfNotFound: true);
        m_GamepadController_MoveRight = m_GamepadController.FindAction("Move Right", throwIfNotFound: true);
        m_GamepadController_MoveLeft = m_GamepadController.FindAction("Move Left", throwIfNotFound: true);
        m_GamepadController_Jump = m_GamepadController.FindAction("Jump", throwIfNotFound: true);
        m_GamepadController_Crouch = m_GamepadController.FindAction("Crouch", throwIfNotFound: true);
        m_GamepadController_Up = m_GamepadController.FindAction("Up", throwIfNotFound: true);
        m_GamepadController_Dash = m_GamepadController.FindAction("Dash", throwIfNotFound: true);
        m_GamepadController_Defend = m_GamepadController.FindAction("Defend", throwIfNotFound: true);
        m_GamepadController_AimAttack = m_GamepadController.FindAction("Aim Attack", throwIfNotFound: true);
        m_GamepadController_HoldSecondaryAimAttack = m_GamepadController.FindAction("Hold Secondary Aim Attack", throwIfNotFound: true);
        m_GamepadController_Primary = m_GamepadController.FindAction("Primary", throwIfNotFound: true);
        m_GamepadController_Secondary = m_GamepadController.FindAction("Secondary", throwIfNotFound: true);
        m_GamepadController_Utility1 = m_GamepadController.FindAction("Utility 1", throwIfNotFound: true);
        m_GamepadController_Utility2 = m_GamepadController.FindAction("Utility 2", throwIfNotFound: true);
        m_GamepadController_Inventory = m_GamepadController.FindAction("Inventory", throwIfNotFound: true);
        m_GamepadController_PauseGame = m_GamepadController.FindAction("Pause Game", throwIfNotFound: true);
        // Pause Menu
        m_PauseMenu = asset.FindActionMap("Pause Menu", throwIfNotFound: true);
        m_PauseMenu_PauseGame = m_PauseMenu.FindAction("Pause Game", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_Inventory = m_Inventory.FindAction("Inventory", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mouse And Keyboard
    private readonly InputActionMap m_MouseAndKeyboard;
    private IMouseAndKeyboardActions m_MouseAndKeyboardActionsCallbackInterface;
    private readonly InputAction m_MouseAndKeyboard_MoveRight;
    private readonly InputAction m_MouseAndKeyboard_MoveLeft;
    private readonly InputAction m_MouseAndKeyboard_Jump;
    private readonly InputAction m_MouseAndKeyboard_Crouch;
    private readonly InputAction m_MouseAndKeyboard_Up;
    private readonly InputAction m_MouseAndKeyboard_Dash;
    private readonly InputAction m_MouseAndKeyboard_Defend;
    private readonly InputAction m_MouseAndKeyboard_Aim;
    private readonly InputAction m_MouseAndKeyboard_Primary;
    private readonly InputAction m_MouseAndKeyboard_Secondary;
    private readonly InputAction m_MouseAndKeyboard_Utility1;
    private readonly InputAction m_MouseAndKeyboard_Utility2;
    private readonly InputAction m_MouseAndKeyboard_Inventory;
    private readonly InputAction m_MouseAndKeyboard_PauseGame;
    public struct MouseAndKeyboardActions
    {
        private @VirtualController m_Wrapper;
        public MouseAndKeyboardActions(@VirtualController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_MouseAndKeyboard_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_MouseAndKeyboard_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_MouseAndKeyboard_Jump;
        public InputAction @Crouch => m_Wrapper.m_MouseAndKeyboard_Crouch;
        public InputAction @Up => m_Wrapper.m_MouseAndKeyboard_Up;
        public InputAction @Dash => m_Wrapper.m_MouseAndKeyboard_Dash;
        public InputAction @Defend => m_Wrapper.m_MouseAndKeyboard_Defend;
        public InputAction @Aim => m_Wrapper.m_MouseAndKeyboard_Aim;
        public InputAction @Primary => m_Wrapper.m_MouseAndKeyboard_Primary;
        public InputAction @Secondary => m_Wrapper.m_MouseAndKeyboard_Secondary;
        public InputAction @Utility1 => m_Wrapper.m_MouseAndKeyboard_Utility1;
        public InputAction @Utility2 => m_Wrapper.m_MouseAndKeyboard_Utility2;
        public InputAction @Inventory => m_Wrapper.m_MouseAndKeyboard_Inventory;
        public InputAction @PauseGame => m_Wrapper.m_MouseAndKeyboard_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_MouseAndKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseAndKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IMouseAndKeyboardActions instance)
        {
            if (m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface != null)
            {
                @MoveRight.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMoveRight;
                @MoveLeft.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMoveLeft;
                @Jump.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnCrouch;
                @Up.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUp;
                @Dash.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnDash;
                @Defend.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnDefend;
                @Defend.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnDefend;
                @Defend.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnDefend;
                @Aim.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnAim;
                @Primary.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnPrimary;
                @Secondary.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnSecondary;
                @Utility1.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUtility1;
                @Utility1.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUtility1;
                @Utility1.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUtility1;
                @Utility2.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUtility2;
                @Utility2.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUtility2;
                @Utility2.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnUtility2;
                @Inventory.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnInventory;
                @PauseGame.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Defend.started += instance.OnDefend;
                @Defend.performed += instance.OnDefend;
                @Defend.canceled += instance.OnDefend;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @Utility1.started += instance.OnUtility1;
                @Utility1.performed += instance.OnUtility1;
                @Utility1.canceled += instance.OnUtility1;
                @Utility2.started += instance.OnUtility2;
                @Utility2.performed += instance.OnUtility2;
                @Utility2.canceled += instance.OnUtility2;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public MouseAndKeyboardActions @MouseAndKeyboard => new MouseAndKeyboardActions(this);

    // Gamepad Controller
    private readonly InputActionMap m_GamepadController;
    private IGamepadControllerActions m_GamepadControllerActionsCallbackInterface;
    private readonly InputAction m_GamepadController_MoveRight;
    private readonly InputAction m_GamepadController_MoveLeft;
    private readonly InputAction m_GamepadController_Jump;
    private readonly InputAction m_GamepadController_Crouch;
    private readonly InputAction m_GamepadController_Up;
    private readonly InputAction m_GamepadController_Dash;
    private readonly InputAction m_GamepadController_Defend;
    private readonly InputAction m_GamepadController_AimAttack;
    private readonly InputAction m_GamepadController_HoldSecondaryAimAttack;
    private readonly InputAction m_GamepadController_Primary;
    private readonly InputAction m_GamepadController_Secondary;
    private readonly InputAction m_GamepadController_Utility1;
    private readonly InputAction m_GamepadController_Utility2;
    private readonly InputAction m_GamepadController_Inventory;
    private readonly InputAction m_GamepadController_PauseGame;
    public struct GamepadControllerActions
    {
        private @VirtualController m_Wrapper;
        public GamepadControllerActions(@VirtualController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_GamepadController_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_GamepadController_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_GamepadController_Jump;
        public InputAction @Crouch => m_Wrapper.m_GamepadController_Crouch;
        public InputAction @Up => m_Wrapper.m_GamepadController_Up;
        public InputAction @Dash => m_Wrapper.m_GamepadController_Dash;
        public InputAction @Defend => m_Wrapper.m_GamepadController_Defend;
        public InputAction @AimAttack => m_Wrapper.m_GamepadController_AimAttack;
        public InputAction @HoldSecondaryAimAttack => m_Wrapper.m_GamepadController_HoldSecondaryAimAttack;
        public InputAction @Primary => m_Wrapper.m_GamepadController_Primary;
        public InputAction @Secondary => m_Wrapper.m_GamepadController_Secondary;
        public InputAction @Utility1 => m_Wrapper.m_GamepadController_Utility1;
        public InputAction @Utility2 => m_Wrapper.m_GamepadController_Utility2;
        public InputAction @Inventory => m_Wrapper.m_GamepadController_Inventory;
        public InputAction @PauseGame => m_Wrapper.m_GamepadController_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_GamepadController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadControllerActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadControllerActions instance)
        {
            if (m_Wrapper.m_GamepadControllerActionsCallbackInterface != null)
            {
                @MoveRight.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMoveRight;
                @MoveLeft.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMoveLeft;
                @Jump.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnCrouch;
                @Up.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUp;
                @Dash.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnDash;
                @Defend.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnDefend;
                @Defend.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnDefend;
                @Defend.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnDefend;
                @AimAttack.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnAimAttack;
                @AimAttack.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnAimAttack;
                @AimAttack.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnAimAttack;
                @HoldSecondaryAimAttack.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnHoldSecondaryAimAttack;
                @HoldSecondaryAimAttack.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnHoldSecondaryAimAttack;
                @HoldSecondaryAimAttack.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnHoldSecondaryAimAttack;
                @Primary.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnPrimary;
                @Secondary.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnSecondary;
                @Utility1.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUtility1;
                @Utility1.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUtility1;
                @Utility1.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUtility1;
                @Utility2.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUtility2;
                @Utility2.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUtility2;
                @Utility2.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnUtility2;
                @Inventory.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnInventory;
                @PauseGame.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_GamepadControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Defend.started += instance.OnDefend;
                @Defend.performed += instance.OnDefend;
                @Defend.canceled += instance.OnDefend;
                @AimAttack.started += instance.OnAimAttack;
                @AimAttack.performed += instance.OnAimAttack;
                @AimAttack.canceled += instance.OnAimAttack;
                @HoldSecondaryAimAttack.started += instance.OnHoldSecondaryAimAttack;
                @HoldSecondaryAimAttack.performed += instance.OnHoldSecondaryAimAttack;
                @HoldSecondaryAimAttack.canceled += instance.OnHoldSecondaryAimAttack;
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @Utility1.started += instance.OnUtility1;
                @Utility1.performed += instance.OnUtility1;
                @Utility1.canceled += instance.OnUtility1;
                @Utility2.started += instance.OnUtility2;
                @Utility2.performed += instance.OnUtility2;
                @Utility2.canceled += instance.OnUtility2;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public GamepadControllerActions @GamepadController => new GamepadControllerActions(this);

    // Pause Menu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_PauseGame;
    public struct PauseMenuActions
    {
        private @VirtualController m_Wrapper;
        public PauseMenuActions(@VirtualController wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseGame => m_Wrapper.m_PauseMenu_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @PauseGame.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_Inventory;
    public struct InventoryActions
    {
        private @VirtualController m_Wrapper;
        public InventoryActions(@VirtualController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_Inventory_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard+Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IMouseAndKeyboardActions
    {
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDefend(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnUtility1(InputAction.CallbackContext context);
        void OnUtility2(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IGamepadControllerActions
    {
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDefend(InputAction.CallbackContext context);
        void OnAimAttack(InputAction.CallbackContext context);
        void OnHoldSecondaryAimAttack(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnUtility1(InputAction.CallbackContext context);
        void OnUtility2(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnInventory(InputAction.CallbackContext context);
    }
}
