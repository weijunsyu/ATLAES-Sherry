// GENERATED AUTOMATICALLY FROM 'Assets/IO/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
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
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""6ec68bd7-4b2f-4786-a9bc-630b0fbcb0ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Button"",
                    ""id"": ""3f597fe4-f510-457c-af9c-aabc138e32a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium"",
                    ""type"": ""Button"",
                    ""id"": ""06159f99-66a1-4437-a80a-78403d579504"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy"",
                    ""type"": ""Button"",
                    ""id"": ""f7a48f45-c224-4b9c-a24d-ed356c7916bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""3055e0d2-a036-47fc-bec9-dfec69078b1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Burst"",
                    ""type"": ""Button"",
                    ""id"": ""89d19db0-35b5-4835-85ca-baabdf9f59fb"",
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
                    ""id"": ""21c7a3dd-d560-4dc3-a552-ccb62e66fc82"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
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
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc0b3284-c3a0-45ce-bb3c-d94515e015b2"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Medium"",
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
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c50da95b-35c2-4705-8093-41b809d56b09"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Light"",
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
                    ""id"": ""e00b9d08-b626-4514-bdd4-96cd069df1c2"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Dash"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""de8c02e7-bb28-428f-a304-a703cd9773e8"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e239079-7b98-49ea-887b-37a2b62abecc"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee8800a7-f428-4279-b082-92937fd6e96f"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1344b751-6adc-41ec-8193-a2ef3e2b039a"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fafcdcc-3e5f-49f9-803d-d3f3b16c3381"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c14f1504-7d71-4377-bce5-e4f5d6df1269"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3580775-d0e1-4555-969b-5c6b8f4c2d14"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a25fcb6f-23b2-4def-baa1-d6551ae0381d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e185f5f1-6608-4801-9ea1-03f5ce2b5d4f"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
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
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""4043881a-5eb7-4839-ae21-73fd1bc1e2f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Button"",
                    ""id"": ""a0d5ee3c-805b-4c54-a18d-c3e90b31a4e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium"",
                    ""type"": ""Button"",
                    ""id"": ""65926634-e774-47b1-aaa8-7ae6becd8d5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy"",
                    ""type"": ""Button"",
                    ""id"": ""8e84932e-89d3-4049-a1bc-bad3459b0084"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""d05aeabe-3301-4716-807f-be770499ad43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Burst"",
                    ""type"": ""Button"",
                    ""id"": ""257a4f89-b51c-4029-9a72-49a902f3ade3"",
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
                    ""path"": ""<XInputController>/dpad/right"",
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
                    ""path"": ""<XInputController>/leftStick/right"",
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
                    ""path"": ""<XInputController>/dpad/left"",
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
                    ""path"": ""<XInputController>/leftStick/left"",
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
                    ""path"": ""<XInputController>/buttonSouth"",
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
                    ""path"": ""<XInputController>/dpad/down"",
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
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd6d286e-122a-4320-a106-c4ba9a856222"",
                    ""path"": ""<XInputController>/dpad/up"",
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
                    ""path"": ""<XInputController>/leftStick/up"",
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
                    ""path"": ""<XInputController>/buttonEast"",
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
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd889d7-4f2b-4d60-8623-39c0165da38f"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a53c83eb-8d5d-46fd-8463-4dcc9ab9e71d"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aaf38e0-4ed4-4a6a-bc96-770eca2ef733"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73c06646-9881-4e0e-963c-83849c6fa9ba"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0470fc17-c823-46ac-bc97-f4df3207fe40"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a864a3c5-6339-4b16-ac4f-14bcda603cb9"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8797a1fb-55e9-45a0-bb4c-37b1f31e9ee3"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Burst"",
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
                    ""name"": ""Resume Game"",
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
                    ""action"": ""Resume Game"",
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
                    ""action"": ""Resume Game"",
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
                    ""isOptional"": true,
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
        m_MouseAndKeyboard_Guard = m_MouseAndKeyboard.FindAction("Guard", throwIfNotFound: true);
        m_MouseAndKeyboard_Light = m_MouseAndKeyboard.FindAction("Light", throwIfNotFound: true);
        m_MouseAndKeyboard_Medium = m_MouseAndKeyboard.FindAction("Medium", throwIfNotFound: true);
        m_MouseAndKeyboard_Heavy = m_MouseAndKeyboard.FindAction("Heavy", throwIfNotFound: true);
        m_MouseAndKeyboard_SwitchWeapon = m_MouseAndKeyboard.FindAction("Switch Weapon", throwIfNotFound: true);
        m_MouseAndKeyboard_Burst = m_MouseAndKeyboard.FindAction("Burst", throwIfNotFound: true);
        m_MouseAndKeyboard_PauseGame = m_MouseAndKeyboard.FindAction("Pause Game", throwIfNotFound: true);
        // Gamepad Controller
        m_GamepadController = asset.FindActionMap("Gamepad Controller", throwIfNotFound: true);
        m_GamepadController_MoveRight = m_GamepadController.FindAction("Move Right", throwIfNotFound: true);
        m_GamepadController_MoveLeft = m_GamepadController.FindAction("Move Left", throwIfNotFound: true);
        m_GamepadController_Jump = m_GamepadController.FindAction("Jump", throwIfNotFound: true);
        m_GamepadController_Crouch = m_GamepadController.FindAction("Crouch", throwIfNotFound: true);
        m_GamepadController_Up = m_GamepadController.FindAction("Up", throwIfNotFound: true);
        m_GamepadController_Dash = m_GamepadController.FindAction("Dash", throwIfNotFound: true);
        m_GamepadController_Guard = m_GamepadController.FindAction("Guard", throwIfNotFound: true);
        m_GamepadController_Light = m_GamepadController.FindAction("Light", throwIfNotFound: true);
        m_GamepadController_Medium = m_GamepadController.FindAction("Medium", throwIfNotFound: true);
        m_GamepadController_Heavy = m_GamepadController.FindAction("Heavy", throwIfNotFound: true);
        m_GamepadController_SwitchWeapon = m_GamepadController.FindAction("Switch Weapon", throwIfNotFound: true);
        m_GamepadController_Burst = m_GamepadController.FindAction("Burst", throwIfNotFound: true);
        m_GamepadController_PauseGame = m_GamepadController.FindAction("Pause Game", throwIfNotFound: true);
        // Pause Menu
        m_PauseMenu = asset.FindActionMap("Pause Menu", throwIfNotFound: true);
        m_PauseMenu_ResumeGame = m_PauseMenu.FindAction("Resume Game", throwIfNotFound: true);
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
    private readonly InputAction m_MouseAndKeyboard_Guard;
    private readonly InputAction m_MouseAndKeyboard_Light;
    private readonly InputAction m_MouseAndKeyboard_Medium;
    private readonly InputAction m_MouseAndKeyboard_Heavy;
    private readonly InputAction m_MouseAndKeyboard_SwitchWeapon;
    private readonly InputAction m_MouseAndKeyboard_Burst;
    private readonly InputAction m_MouseAndKeyboard_PauseGame;
    public struct MouseAndKeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public MouseAndKeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_MouseAndKeyboard_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_MouseAndKeyboard_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_MouseAndKeyboard_Jump;
        public InputAction @Crouch => m_Wrapper.m_MouseAndKeyboard_Crouch;
        public InputAction @Up => m_Wrapper.m_MouseAndKeyboard_Up;
        public InputAction @Dash => m_Wrapper.m_MouseAndKeyboard_Dash;
        public InputAction @Guard => m_Wrapper.m_MouseAndKeyboard_Guard;
        public InputAction @Light => m_Wrapper.m_MouseAndKeyboard_Light;
        public InputAction @Medium => m_Wrapper.m_MouseAndKeyboard_Medium;
        public InputAction @Heavy => m_Wrapper.m_MouseAndKeyboard_Heavy;
        public InputAction @SwitchWeapon => m_Wrapper.m_MouseAndKeyboard_SwitchWeapon;
        public InputAction @Burst => m_Wrapper.m_MouseAndKeyboard_Burst;
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
                @Guard.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnGuard;
                @Light.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnLight;
                @Medium.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMedium;
                @Medium.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMedium;
                @Medium.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnMedium;
                @Heavy.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnHeavy;
                @SwitchWeapon.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnSwitchWeapon;
                @Burst.started -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnBurst;
                @Burst.performed -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnBurst;
                @Burst.canceled -= m_Wrapper.m_MouseAndKeyboardActionsCallbackInterface.OnBurst;
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
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Medium.started += instance.OnMedium;
                @Medium.performed += instance.OnMedium;
                @Medium.canceled += instance.OnMedium;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Burst.started += instance.OnBurst;
                @Burst.performed += instance.OnBurst;
                @Burst.canceled += instance.OnBurst;
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
    private readonly InputAction m_GamepadController_Guard;
    private readonly InputAction m_GamepadController_Light;
    private readonly InputAction m_GamepadController_Medium;
    private readonly InputAction m_GamepadController_Heavy;
    private readonly InputAction m_GamepadController_SwitchWeapon;
    private readonly InputAction m_GamepadController_Burst;
    private readonly InputAction m_GamepadController_PauseGame;
    public struct GamepadControllerActions
    {
        private @PlayerControls m_Wrapper;
        public GamepadControllerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_GamepadController_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_GamepadController_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_GamepadController_Jump;
        public InputAction @Crouch => m_Wrapper.m_GamepadController_Crouch;
        public InputAction @Up => m_Wrapper.m_GamepadController_Up;
        public InputAction @Dash => m_Wrapper.m_GamepadController_Dash;
        public InputAction @Guard => m_Wrapper.m_GamepadController_Guard;
        public InputAction @Light => m_Wrapper.m_GamepadController_Light;
        public InputAction @Medium => m_Wrapper.m_GamepadController_Medium;
        public InputAction @Heavy => m_Wrapper.m_GamepadController_Heavy;
        public InputAction @SwitchWeapon => m_Wrapper.m_GamepadController_SwitchWeapon;
        public InputAction @Burst => m_Wrapper.m_GamepadController_Burst;
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
                @Guard.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnGuard;
                @Light.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnLight;
                @Medium.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMedium;
                @Medium.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMedium;
                @Medium.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnMedium;
                @Heavy.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnHeavy;
                @SwitchWeapon.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnSwitchWeapon;
                @Burst.started -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnBurst;
                @Burst.performed -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnBurst;
                @Burst.canceled -= m_Wrapper.m_GamepadControllerActionsCallbackInterface.OnBurst;
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
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Medium.started += instance.OnMedium;
                @Medium.performed += instance.OnMedium;
                @Medium.canceled += instance.OnMedium;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Burst.started += instance.OnBurst;
                @Burst.performed += instance.OnBurst;
                @Burst.canceled += instance.OnBurst;
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
    private readonly InputAction m_PauseMenu_ResumeGame;
    public struct PauseMenuActions
    {
        private @PlayerControls m_Wrapper;
        public PauseMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResumeGame => m_Wrapper.m_PauseMenu_ResumeGame;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @ResumeGame.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnResumeGame;
                @ResumeGame.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnResumeGame;
                @ResumeGame.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnResumeGame;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ResumeGame.started += instance.OnResumeGame;
                @ResumeGame.performed += instance.OnResumeGame;
                @ResumeGame.canceled += instance.OnResumeGame;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);
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
        void OnGuard(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMedium(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
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
        void OnGuard(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMedium(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnResumeGame(InputAction.CallbackContext context);
    }
}
