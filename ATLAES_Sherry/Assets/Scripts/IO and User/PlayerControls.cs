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
            ""name"": ""Keyboard"",
            ""id"": ""c0085b57-853b-41aa-b461-8523d633ee09"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""83af9e11-ec3c-4e27-8aab-c777ece51fc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
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
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""1526bed1-988b-4256-af3c-a0202b181062"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""51b396bd-c4b8-45dc-a480-6c975d99a18a"",
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
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""6ec68bd7-4b2f-4786-a9bc-630b0fbcb0ea"",
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
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""d56f6e48-9f9e-428b-ad42-ff32a3e866be"",
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5e7f92bc-15a6-4614-af06-bb7d5c4f3047"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7441e45a-046f-45e7-be42-7de9e6b52cbd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc0b3284-c3a0-45ce-bb3c-d94515e015b2"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c50da95b-35c2-4705-8093-41b809d56b09"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
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
                    ""groups"": """",
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
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e00b9d08-b626-4514-bdd4-96cd069df1c2"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fafcdcc-3e5f-49f9-803d-d3f3b16c3381"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
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
                    ""id"": ""41856f60-dba9-4c32-8e8e-692b82175c2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3580775-d0e1-4555-969b-5c6b8f4c2d14"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e185f5f1-6608-4801-9ea1-03f5ce2b5d4f"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87e211ac-a1cd-41ee-b39f-0089725baa45"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""id"": ""e81e1319-f424-4035-9179-dbdd2473d892"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b78ac80b-3223-45dd-9474-bf507eedfad3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""59404323-1722-4b3c-80c3-75b9c2d0a8c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Burst"",
                    ""type"": ""Button"",
                    ""id"": ""129e96ae-03ab-4908-8b73-2984d4c3573c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""5b93dad7-ce1f-4c32-abb1-76df6b2d30ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""45895d5d-8227-4960-a233-babda590466d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""8de69b85-57e6-4d55-8319-21ccec193600"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""ccdf225b-ffbc-4847-978e-30da0cafbb4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""f567bb1b-368d-4011-beab-aedb517e8a5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bfeb95fd-fe78-4a3f-a201-d54bfc2653d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""8e6416e9-e225-4c08-a842-03cd8155a9d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Button"",
                    ""id"": ""33cfbd90-5c8e-46e6-adfa-493a7ab2bad8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium"",
                    ""type"": ""Button"",
                    ""id"": ""8f53ee5e-a27e-48a5-9508-6c12919ed257"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy"",
                    ""type"": ""Button"",
                    ""id"": ""fd959a29-b49c-4c16-a5cb-5ed184f71afe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""159b6eae-41d6-4ab6-918e-e62b40295842"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98e883a9-60be-4b9d-ac92-d2d46e857a8f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1de6b004-44db-46a1-9cee-ac785bec8aa0"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4c8fa7f-0c8f-4fbb-a168-b9be5d166fd3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""039e62c3-8348-40b5-a4d7-f294ba12b639"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c10b6991-7ab0-4ddb-997a-cf6e30223904"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2eb3b688-228c-4959-b31c-faee58c502ba"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b311bbf-5527-48b1-9d8b-4c2f60827428"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a38dec06-4894-45c7-adda-758ab23c08c1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""245fb917-dd98-4864-a866-3729f63a1fca"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1faf1b93-5660-4549-a070-9281c1303ad0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0d95967-51e5-4492-ac45-9bee739f9f62"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""446387bc-1ac4-4362-a360-47191c5210a6"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerTwo"",
            ""id"": ""10f09fe9-4758-4a22-91fa-7c3916cd14f7"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""64491dc4-94e0-4e7a-ae78-47e956484c96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""62417246-a15e-40c0-85bf-4e55df847c59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Burst"",
                    ""type"": ""Button"",
                    ""id"": ""77d27971-612a-4728-9e7a-1cdf0e8fad2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""d86070ba-da0d-4cb1-88c6-2f770252a571"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""da368811-1e0f-4407-bef9-32c1cb4a624e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""5e30c88a-ab26-411d-a124-23882e9035f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""0abdc2a3-0f99-4d66-a995-e5586eb1fefc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""0eff494b-d102-4493-bb7f-408a3b7f37df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ab33368f-cd7e-4df1-b770-280e43dd376b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""3b047316-13f5-4651-b696-73d888754a8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Button"",
                    ""id"": ""fb2ff4ba-28a9-4c26-a237-135e669c67e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium"",
                    ""type"": ""Button"",
                    ""id"": ""d2950dc3-f20d-4e30-a085-860c87652e31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy"",
                    ""type"": ""Button"",
                    ""id"": ""0486dff8-2f5e-417c-8a32-27c6c6bd6dc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5339d482-68d8-4970-8900-dc93ef2d195a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71b2600e-4f09-4fad-a70a-2fa33e4663a5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e6f0178-49cd-4efc-a8a2-63bd132540a7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b74f89b0-97d6-46fe-ba91-d9b43b9ddf0b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5635df1-89be-4a47-a9e3-7488e6da17da"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b444505d-9e7d-4f17-9104-81d9ec1ad27a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95bcd773-da10-4839-8789-17a2d5167fd4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca6ea0d8-8ee3-43ec-8073-1a625bf0144c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd34c380-1b04-4c93-ba80-151c0ff93fd7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aec60a10-13e7-4840-b022-397477e6e398"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff316132-a453-426d-9689-ff1d651c94ce"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""273300ae-b34f-4699-8c9b-30057e99948e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4ea3ffa-f6ab-4c61-8f88-685e4700d30b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GamepadDefaults"",
            ""id"": ""cc0f2e71-d193-49b6-b1eb-4ed8b6af7de1"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b1c70a6f-aca2-4b45-9d24-de545c17600f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""075f411d-7253-4fb1-820c-805047c7a238"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Burst"",
                    ""type"": ""Button"",
                    ""id"": ""c512c913-3e45-4ca2-91fd-bd0f886beefb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""ed9db3be-eac4-4087-b09d-2584e5dc5ce6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""cac08c67-da0c-4e3a-97ee-9c3f25503770"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""44cc2868-3839-4534-8835-1ed9bbd93b28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""dec36421-fc0c-4411-915e-6388f01bbed3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""5e75ccf5-9976-46f6-b283-113c68b4597b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""60764e4f-2145-46f2-9762-4f84335331e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""36bf622a-3874-460c-a803-e8f2a30a54a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Button"",
                    ""id"": ""598641aa-0d0b-4534-8356-8548a9fc3d5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium"",
                    ""type"": ""Button"",
                    ""id"": ""e56e9c44-1795-4b1e-a35a-02d088b60fce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy"",
                    ""type"": ""Button"",
                    ""id"": ""139142d6-84fc-48f0-8812-13d73b36f228"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6692e2fa-184e-437c-b2c0-8eba9129455c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22d2d0e9-e7c0-4afe-8911-5cdbfe21dff0"",
                    ""path"": ""<AndroidGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f979fe5-9916-471f-8031-f358f23cbd0f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""057b2750-258c-4b1f-a63c-b033eea08874"",
                    ""path"": ""<AndroidGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5106ab12-7d67-4633-a66f-8dc1f97a3825"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a6b0674-edcb-473b-bce8-7915dbddd2fb"",
                    ""path"": ""<AndroidGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d4efc2b-8e3f-4042-8dce-98f1d11354f6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25bf3044-566a-4730-b9f1-2b0f74280ac8"",
                    ""path"": ""<AndroidGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c910e11d-efd0-499c-bdf5-2092b0217e83"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09c80dd7-3f3e-4a45-8f7b-12d5fb11eb71"",
                    ""path"": ""<AndroidGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""698ef454-f118-48e5-9ae7-cfa529eb18a5"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b12703de-2987-4430-988f-fdaeb6d033e3"",
                    ""path"": ""<AndroidGamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3a646ca-3b9a-4353-b0f5-78f4cf7223d2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54167c8f-0caf-4b96-8d5a-2af888184eb5"",
                    ""path"": ""<AndroidGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f78f8a1-f1a4-45b4-b932-86bc8f5083ba"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9949c11e-1c4e-427b-b73c-8795e6e5362f"",
                    ""path"": ""<AndroidGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e33dde33-2df8-47d2-908d-5212a0f9fd5a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ca0893b-03fc-4229-b2e2-ba9b45d5c46a"",
                    ""path"": ""<AndroidGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1fbd583-8948-4d5c-9c00-ee37053412a4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5264fb7e-9573-4bc9-9409-0c84d9787fee"",
                    ""path"": ""<AndroidGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f34d0c8-179a-40db-ad03-6f7bd9d8fa4b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""741643b9-6f1f-472f-97dc-b3b043f1ef70"",
                    ""path"": ""<AndroidGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c806f4e6-c4e8-4bd2-b6ac-86c371836c58"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98d0ed2e-7a30-4a95-8349-b45edd5427f4"",
                    ""path"": ""<AndroidGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a3c28ca-624e-48de-a128-00e25150540c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65a0e782-cb88-420f-90e4-9dea4b0eff6d"",
                    ""path"": ""<AndroidGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e07f3e58-3526-4e67-9636-ade292fcb66e"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a09f8878-6ab3-462f-9ea3-1da3d932a12a"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cc91c17-bdb6-4742-8682-61ccb07c0b03"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""612460b9-3618-4c69-8a85-74df9ae43d48"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e8330ca-ced3-4a16-922f-5bcc389cb896"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""760bc5ce-ada6-474c-949a-aa95a95fe991"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b7446c6-dfda-4c63-bed3-88d837292dd2"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ecc5060-5131-433b-b2a2-a22b35efdc0c"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""532a441f-bbbb-4b61-a0a5-5eb27025f6bd"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76c25f77-053a-4f29-801f-6f12ca1dae96"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71972e99-cbb7-4b50-88db-d413ae34ae40"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a001fc24-e6ea-49f9-ada1-77abc57a4e33"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05ebca24-c1b8-42f2-a5a4-1c2f0757d30f"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a4ccce0-c8ee-4aea-8b36-96ea1bd14be7"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28dccda0-c3a0-47d2-aecb-5c7d4ad38e6e"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a771fa-feaf-451f-8f91-3dbc7c6b47cf"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""832d218d-8249-4932-8764-a2830d94d594"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91c532a1-9fe7-41e4-b21c-2e789b7f3482"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b11a2ac-21f1-4c29-99f6-ff7bf0eff582"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e220ea35-0f70-4757-ae2d-f193d295a260"",
                    ""path"": ""<DualShockGamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""520dbb38-d0be-4d9b-b371-19dde99d6bc7"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d71aac6e-9623-48f8-9d61-5bd26bb416c6"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c418b16a-976a-41dc-ba35-42a868f10622"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""089aefe4-cd6e-4c37-ba18-359c40d1eae4"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cae7f468-a771-4b5e-a28b-52965d3e0e8c"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f299a8f1-6cf0-42df-8976-fc9f7e66c2f8"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21cc2edf-0a48-437f-8d7a-609789f2042f"",
                    ""path"": ""<SwitchProControllerHID>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2140422-e3c6-40c2-a163-f5f1818643f3"",
                    ""path"": ""<SwitchProControllerHID>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ae6cd5a-ee48-44f1-be34-48ca250e434e"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d886b62a-c925-4bfe-a608-b0aba7e60ebe"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b91476c7-e614-47ec-bffd-3e0860436a48"",
                    ""path"": ""<SwitchProControllerHID>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f597807-3e09-45d2-a271-85f961229b28"",
                    ""path"": ""<SwitchProControllerHID>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2665a37b-c73c-4ea9-8fb7-4f02131e0dd3"",
                    ""path"": ""<SwitchProControllerHID>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f342ccf-e956-4fa4-9b62-c5cb68a43ff1"",
                    ""path"": ""<SwitchProControllerHID>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6336d0bf-b130-438a-be46-db702ea3ea4b"",
                    ""path"": ""<SwitchProControllerHID>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a600e224-c5bd-4710-b802-64d3fc95d595"",
                    ""path"": ""<SwitchProControllerHID>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcccb1b7-7e42-482b-858d-d57466d6b4bf"",
                    ""path"": ""<SwitchProControllerHID>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d56ab40-26b6-41a0-a6ee-a9c4cd6e1be5"",
                    ""path"": ""<SwitchProControllerHID>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8cf240f-8eb5-4ca6-8e3e-8a0aa10b18db"",
                    ""path"": ""<SwitchProControllerHID>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""845da3a2-e3cb-4e87-9c1a-3af56891db33"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee298148-71e9-47b9-a8e9-8744440537bb"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8246d14-9010-4632-afc8-946a2564da57"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f1fbecb-b923-4c84-97bc-24db7ed600ec"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a462d857-513d-4f0b-b39f-9c82bf829697"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a92eb8c-0a1d-4c14-89e0-ee2a8f8963f2"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17bb0802-6038-4bf0-a011-51acbd1adbbc"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9237c7e0-fec0-40c7-b8fb-0d080531ef60"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35773281-0c4b-40ec-a121-c8d279f622f3"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bb8012c-71b6-4e88-8115-d42b22667e97"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""388952a0-74af-497f-a525-1fa325c7b812"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12e87a46-f0fa-4f82-9647-c5f9333919a5"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fbb0d34-5220-42e6-951c-328348529c06"",
                    ""path"": ""<HID::szmy-power Ltd.  8BitDo SN30 Pro for Android >/button12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed9c3ba8-3e63-409a-8c55-3fdd9e9652c1"",
                    ""path"": ""<AndroidGamepadXboxController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25ac342e-3f9d-438b-bf99-05fe6c2a2615"",
                    ""path"": ""<AndroidGamepadXboxController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c2d110a-5204-42bd-aafe-914e0b40203e"",
                    ""path"": ""<AndroidGamepadXboxController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b9dec47-23b2-4a3f-b9c7-f9eec458a5f2"",
                    ""path"": ""<AndroidGamepadXboxController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""548c1067-40ae-46cd-9649-fab03a0534cb"",
                    ""path"": ""<AndroidGamepadXboxController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b005724e-0059-45bd-8d78-24dfa48fa8a0"",
                    ""path"": ""<AndroidGamepadXboxController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbd6053a-9453-4d24-af9a-eac740b92cdf"",
                    ""path"": ""<AndroidGamepadXboxController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaf6acb9-c223-40f1-bf53-dce3862ff906"",
                    ""path"": ""<AndroidGamepadXboxController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79188f2e-ea06-42fd-826b-ae8af5da8d4f"",
                    ""path"": ""<AndroidGamepadXboxController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14dd98ab-487b-4f07-afe7-8bac3dde2535"",
                    ""path"": ""<AndroidGamepadXboxController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1600a0e8-7657-4df6-9afe-cbda5688810f"",
                    ""path"": ""<AndroidGamepadXboxController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Burst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20d4e88a-5a40-4696-b731-98b44ff21e7a"",
                    ""path"": ""<AndroidGamepadXboxController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63b669e0-928c-4da3-93d7-442fd821a0aa"",
                    ""path"": ""<AndroidGamepadXboxController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Pause = m_Keyboard.FindAction("Pause", throwIfNotFound: true);
        m_Keyboard_SwitchWeapon = m_Keyboard.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_Keyboard_Burst = m_Keyboard.FindAction("Burst", throwIfNotFound: true);
        m_Keyboard_Right = m_Keyboard.FindAction("Right", throwIfNotFound: true);
        m_Keyboard_Left = m_Keyboard.FindAction("Left", throwIfNotFound: true);
        m_Keyboard_Crouch = m_Keyboard.FindAction("Crouch", throwIfNotFound: true);
        m_Keyboard_Up = m_Keyboard.FindAction("Up", throwIfNotFound: true);
        m_Keyboard_Guard = m_Keyboard.FindAction("Guard", throwIfNotFound: true);
        m_Keyboard_Jump = m_Keyboard.FindAction("Jump", throwIfNotFound: true);
        m_Keyboard_Dash = m_Keyboard.FindAction("Dash", throwIfNotFound: true);
        m_Keyboard_Light = m_Keyboard.FindAction("Light", throwIfNotFound: true);
        m_Keyboard_Medium = m_Keyboard.FindAction("Medium", throwIfNotFound: true);
        m_Keyboard_Heavy = m_Keyboard.FindAction("Heavy", throwIfNotFound: true);
        // Gamepad
        m_Gamepad = asset.FindActionMap("Gamepad", throwIfNotFound: true);
        m_Gamepad_Pause = m_Gamepad.FindAction("Pause", throwIfNotFound: true);
        m_Gamepad_SwitchWeapon = m_Gamepad.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_Gamepad_Burst = m_Gamepad.FindAction("Burst", throwIfNotFound: true);
        m_Gamepad_Right = m_Gamepad.FindAction("Right", throwIfNotFound: true);
        m_Gamepad_Left = m_Gamepad.FindAction("Left", throwIfNotFound: true);
        m_Gamepad_Crouch = m_Gamepad.FindAction("Crouch", throwIfNotFound: true);
        m_Gamepad_Up = m_Gamepad.FindAction("Up", throwIfNotFound: true);
        m_Gamepad_Guard = m_Gamepad.FindAction("Guard", throwIfNotFound: true);
        m_Gamepad_Jump = m_Gamepad.FindAction("Jump", throwIfNotFound: true);
        m_Gamepad_Dash = m_Gamepad.FindAction("Dash", throwIfNotFound: true);
        m_Gamepad_Light = m_Gamepad.FindAction("Light", throwIfNotFound: true);
        m_Gamepad_Medium = m_Gamepad.FindAction("Medium", throwIfNotFound: true);
        m_Gamepad_Heavy = m_Gamepad.FindAction("Heavy", throwIfNotFound: true);
        // PlayerTwo
        m_PlayerTwo = asset.FindActionMap("PlayerTwo", throwIfNotFound: true);
        m_PlayerTwo_Pause = m_PlayerTwo.FindAction("Pause", throwIfNotFound: true);
        m_PlayerTwo_SwitchWeapon = m_PlayerTwo.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_PlayerTwo_Burst = m_PlayerTwo.FindAction("Burst", throwIfNotFound: true);
        m_PlayerTwo_Right = m_PlayerTwo.FindAction("Right", throwIfNotFound: true);
        m_PlayerTwo_Left = m_PlayerTwo.FindAction("Left", throwIfNotFound: true);
        m_PlayerTwo_Crouch = m_PlayerTwo.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerTwo_Up = m_PlayerTwo.FindAction("Up", throwIfNotFound: true);
        m_PlayerTwo_Guard = m_PlayerTwo.FindAction("Guard", throwIfNotFound: true);
        m_PlayerTwo_Jump = m_PlayerTwo.FindAction("Jump", throwIfNotFound: true);
        m_PlayerTwo_Dash = m_PlayerTwo.FindAction("Dash", throwIfNotFound: true);
        m_PlayerTwo_Light = m_PlayerTwo.FindAction("Light", throwIfNotFound: true);
        m_PlayerTwo_Medium = m_PlayerTwo.FindAction("Medium", throwIfNotFound: true);
        m_PlayerTwo_Heavy = m_PlayerTwo.FindAction("Heavy", throwIfNotFound: true);
        // GamepadDefaults
        m_GamepadDefaults = asset.FindActionMap("GamepadDefaults", throwIfNotFound: true);
        m_GamepadDefaults_Pause = m_GamepadDefaults.FindAction("Pause", throwIfNotFound: true);
        m_GamepadDefaults_SwitchWeapon = m_GamepadDefaults.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_GamepadDefaults_Burst = m_GamepadDefaults.FindAction("Burst", throwIfNotFound: true);
        m_GamepadDefaults_Right = m_GamepadDefaults.FindAction("Right", throwIfNotFound: true);
        m_GamepadDefaults_Left = m_GamepadDefaults.FindAction("Left", throwIfNotFound: true);
        m_GamepadDefaults_Crouch = m_GamepadDefaults.FindAction("Crouch", throwIfNotFound: true);
        m_GamepadDefaults_Up = m_GamepadDefaults.FindAction("Up", throwIfNotFound: true);
        m_GamepadDefaults_Guard = m_GamepadDefaults.FindAction("Guard", throwIfNotFound: true);
        m_GamepadDefaults_Jump = m_GamepadDefaults.FindAction("Jump", throwIfNotFound: true);
        m_GamepadDefaults_Dash = m_GamepadDefaults.FindAction("Dash", throwIfNotFound: true);
        m_GamepadDefaults_Light = m_GamepadDefaults.FindAction("Light", throwIfNotFound: true);
        m_GamepadDefaults_Medium = m_GamepadDefaults.FindAction("Medium", throwIfNotFound: true);
        m_GamepadDefaults_Heavy = m_GamepadDefaults.FindAction("Heavy", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Pause;
    private readonly InputAction m_Keyboard_SwitchWeapon;
    private readonly InputAction m_Keyboard_Burst;
    private readonly InputAction m_Keyboard_Right;
    private readonly InputAction m_Keyboard_Left;
    private readonly InputAction m_Keyboard_Crouch;
    private readonly InputAction m_Keyboard_Up;
    private readonly InputAction m_Keyboard_Guard;
    private readonly InputAction m_Keyboard_Jump;
    private readonly InputAction m_Keyboard_Dash;
    private readonly InputAction m_Keyboard_Light;
    private readonly InputAction m_Keyboard_Medium;
    private readonly InputAction m_Keyboard_Heavy;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Keyboard_Pause;
        public InputAction @SwitchWeapon => m_Wrapper.m_Keyboard_SwitchWeapon;
        public InputAction @Burst => m_Wrapper.m_Keyboard_Burst;
        public InputAction @Right => m_Wrapper.m_Keyboard_Right;
        public InputAction @Left => m_Wrapper.m_Keyboard_Left;
        public InputAction @Crouch => m_Wrapper.m_Keyboard_Crouch;
        public InputAction @Up => m_Wrapper.m_Keyboard_Up;
        public InputAction @Guard => m_Wrapper.m_Keyboard_Guard;
        public InputAction @Jump => m_Wrapper.m_Keyboard_Jump;
        public InputAction @Dash => m_Wrapper.m_Keyboard_Dash;
        public InputAction @Light => m_Wrapper.m_Keyboard_Light;
        public InputAction @Medium => m_Wrapper.m_Keyboard_Medium;
        public InputAction @Heavy => m_Wrapper.m_Keyboard_Heavy;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPause;
                @SwitchWeapon.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSwitchWeapon;
                @Burst.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnBurst;
                @Burst.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnBurst;
                @Burst.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnBurst;
                @Right.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeft;
                @Crouch.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCrouch;
                @Up.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUp;
                @Guard.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnGuard;
                @Jump.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDash;
                @Light.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLight;
                @Medium.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMedium;
                @Medium.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMedium;
                @Medium.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMedium;
                @Heavy.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHeavy;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Burst.started += instance.OnBurst;
                @Burst.performed += instance.OnBurst;
                @Burst.canceled += instance.OnBurst;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Medium.started += instance.OnMedium;
                @Medium.performed += instance.OnMedium;
                @Medium.canceled += instance.OnMedium;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);

    // Gamepad
    private readonly InputActionMap m_Gamepad;
    private IGamepadActions m_GamepadActionsCallbackInterface;
    private readonly InputAction m_Gamepad_Pause;
    private readonly InputAction m_Gamepad_SwitchWeapon;
    private readonly InputAction m_Gamepad_Burst;
    private readonly InputAction m_Gamepad_Right;
    private readonly InputAction m_Gamepad_Left;
    private readonly InputAction m_Gamepad_Crouch;
    private readonly InputAction m_Gamepad_Up;
    private readonly InputAction m_Gamepad_Guard;
    private readonly InputAction m_Gamepad_Jump;
    private readonly InputAction m_Gamepad_Dash;
    private readonly InputAction m_Gamepad_Light;
    private readonly InputAction m_Gamepad_Medium;
    private readonly InputAction m_Gamepad_Heavy;
    public struct GamepadActions
    {
        private @PlayerControls m_Wrapper;
        public GamepadActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Gamepad_Pause;
        public InputAction @SwitchWeapon => m_Wrapper.m_Gamepad_SwitchWeapon;
        public InputAction @Burst => m_Wrapper.m_Gamepad_Burst;
        public InputAction @Right => m_Wrapper.m_Gamepad_Right;
        public InputAction @Left => m_Wrapper.m_Gamepad_Left;
        public InputAction @Crouch => m_Wrapper.m_Gamepad_Crouch;
        public InputAction @Up => m_Wrapper.m_Gamepad_Up;
        public InputAction @Guard => m_Wrapper.m_Gamepad_Guard;
        public InputAction @Jump => m_Wrapper.m_Gamepad_Jump;
        public InputAction @Dash => m_Wrapper.m_Gamepad_Dash;
        public InputAction @Light => m_Wrapper.m_Gamepad_Light;
        public InputAction @Medium => m_Wrapper.m_Gamepad_Medium;
        public InputAction @Heavy => m_Wrapper.m_Gamepad_Heavy;
        public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadActions instance)
        {
            if (m_Wrapper.m_GamepadActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPause;
                @SwitchWeapon.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnSwitchWeapon;
                @Burst.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnBurst;
                @Burst.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnBurst;
                @Burst.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnBurst;
                @Right.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeft;
                @Crouch.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnCrouch;
                @Up.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnUp;
                @Guard.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnGuard;
                @Jump.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnDash;
                @Light.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLight;
                @Medium.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMedium;
                @Medium.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMedium;
                @Medium.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMedium;
                @Heavy.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnHeavy;
            }
            m_Wrapper.m_GamepadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Burst.started += instance.OnBurst;
                @Burst.performed += instance.OnBurst;
                @Burst.canceled += instance.OnBurst;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Medium.started += instance.OnMedium;
                @Medium.performed += instance.OnMedium;
                @Medium.canceled += instance.OnMedium;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
            }
        }
    }
    public GamepadActions @Gamepad => new GamepadActions(this);

    // PlayerTwo
    private readonly InputActionMap m_PlayerTwo;
    private IPlayerTwoActions m_PlayerTwoActionsCallbackInterface;
    private readonly InputAction m_PlayerTwo_Pause;
    private readonly InputAction m_PlayerTwo_SwitchWeapon;
    private readonly InputAction m_PlayerTwo_Burst;
    private readonly InputAction m_PlayerTwo_Right;
    private readonly InputAction m_PlayerTwo_Left;
    private readonly InputAction m_PlayerTwo_Crouch;
    private readonly InputAction m_PlayerTwo_Up;
    private readonly InputAction m_PlayerTwo_Guard;
    private readonly InputAction m_PlayerTwo_Jump;
    private readonly InputAction m_PlayerTwo_Dash;
    private readonly InputAction m_PlayerTwo_Light;
    private readonly InputAction m_PlayerTwo_Medium;
    private readonly InputAction m_PlayerTwo_Heavy;
    public struct PlayerTwoActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerTwoActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PlayerTwo_Pause;
        public InputAction @SwitchWeapon => m_Wrapper.m_PlayerTwo_SwitchWeapon;
        public InputAction @Burst => m_Wrapper.m_PlayerTwo_Burst;
        public InputAction @Right => m_Wrapper.m_PlayerTwo_Right;
        public InputAction @Left => m_Wrapper.m_PlayerTwo_Left;
        public InputAction @Crouch => m_Wrapper.m_PlayerTwo_Crouch;
        public InputAction @Up => m_Wrapper.m_PlayerTwo_Up;
        public InputAction @Guard => m_Wrapper.m_PlayerTwo_Guard;
        public InputAction @Jump => m_Wrapper.m_PlayerTwo_Jump;
        public InputAction @Dash => m_Wrapper.m_PlayerTwo_Dash;
        public InputAction @Light => m_Wrapper.m_PlayerTwo_Light;
        public InputAction @Medium => m_Wrapper.m_PlayerTwo_Medium;
        public InputAction @Heavy => m_Wrapper.m_PlayerTwo_Heavy;
        public InputActionMap Get() { return m_Wrapper.m_PlayerTwo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerTwoActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerTwoActions instance)
        {
            if (m_Wrapper.m_PlayerTwoActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnPause;
                @SwitchWeapon.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnSwitchWeapon;
                @Burst.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnBurst;
                @Burst.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnBurst;
                @Burst.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnBurst;
                @Right.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnLeft;
                @Crouch.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnCrouch;
                @Up.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnUp;
                @Guard.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnGuard;
                @Jump.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnDash;
                @Light.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnLight;
                @Medium.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnMedium;
                @Medium.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnMedium;
                @Medium.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnMedium;
                @Heavy.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnHeavy;
            }
            m_Wrapper.m_PlayerTwoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Burst.started += instance.OnBurst;
                @Burst.performed += instance.OnBurst;
                @Burst.canceled += instance.OnBurst;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Medium.started += instance.OnMedium;
                @Medium.performed += instance.OnMedium;
                @Medium.canceled += instance.OnMedium;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
            }
        }
    }
    public PlayerTwoActions @PlayerTwo => new PlayerTwoActions(this);

    // GamepadDefaults
    private readonly InputActionMap m_GamepadDefaults;
    private IGamepadDefaultsActions m_GamepadDefaultsActionsCallbackInterface;
    private readonly InputAction m_GamepadDefaults_Pause;
    private readonly InputAction m_GamepadDefaults_SwitchWeapon;
    private readonly InputAction m_GamepadDefaults_Burst;
    private readonly InputAction m_GamepadDefaults_Right;
    private readonly InputAction m_GamepadDefaults_Left;
    private readonly InputAction m_GamepadDefaults_Crouch;
    private readonly InputAction m_GamepadDefaults_Up;
    private readonly InputAction m_GamepadDefaults_Guard;
    private readonly InputAction m_GamepadDefaults_Jump;
    private readonly InputAction m_GamepadDefaults_Dash;
    private readonly InputAction m_GamepadDefaults_Light;
    private readonly InputAction m_GamepadDefaults_Medium;
    private readonly InputAction m_GamepadDefaults_Heavy;
    public struct GamepadDefaultsActions
    {
        private @PlayerControls m_Wrapper;
        public GamepadDefaultsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GamepadDefaults_Pause;
        public InputAction @SwitchWeapon => m_Wrapper.m_GamepadDefaults_SwitchWeapon;
        public InputAction @Burst => m_Wrapper.m_GamepadDefaults_Burst;
        public InputAction @Right => m_Wrapper.m_GamepadDefaults_Right;
        public InputAction @Left => m_Wrapper.m_GamepadDefaults_Left;
        public InputAction @Crouch => m_Wrapper.m_GamepadDefaults_Crouch;
        public InputAction @Up => m_Wrapper.m_GamepadDefaults_Up;
        public InputAction @Guard => m_Wrapper.m_GamepadDefaults_Guard;
        public InputAction @Jump => m_Wrapper.m_GamepadDefaults_Jump;
        public InputAction @Dash => m_Wrapper.m_GamepadDefaults_Dash;
        public InputAction @Light => m_Wrapper.m_GamepadDefaults_Light;
        public InputAction @Medium => m_Wrapper.m_GamepadDefaults_Medium;
        public InputAction @Heavy => m_Wrapper.m_GamepadDefaults_Heavy;
        public InputActionMap Get() { return m_Wrapper.m_GamepadDefaults; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadDefaultsActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadDefaultsActions instance)
        {
            if (m_Wrapper.m_GamepadDefaultsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnPause;
                @SwitchWeapon.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnSwitchWeapon;
                @Burst.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnBurst;
                @Burst.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnBurst;
                @Burst.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnBurst;
                @Right.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnLeft;
                @Crouch.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnCrouch;
                @Up.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnUp;
                @Guard.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnGuard;
                @Guard.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnGuard;
                @Guard.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnGuard;
                @Jump.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnDash;
                @Light.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnLight;
                @Medium.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnMedium;
                @Medium.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnMedium;
                @Medium.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnMedium;
                @Heavy.started -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnHeavy;
                @Heavy.performed -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnHeavy;
                @Heavy.canceled -= m_Wrapper.m_GamepadDefaultsActionsCallbackInterface.OnHeavy;
            }
            m_Wrapper.m_GamepadDefaultsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Burst.started += instance.OnBurst;
                @Burst.performed += instance.OnBurst;
                @Burst.canceled += instance.OnBurst;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Guard.started += instance.OnGuard;
                @Guard.performed += instance.OnGuard;
                @Guard.canceled += instance.OnGuard;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Medium.started += instance.OnMedium;
                @Medium.performed += instance.OnMedium;
                @Medium.canceled += instance.OnMedium;
                @Heavy.started += instance.OnHeavy;
                @Heavy.performed += instance.OnHeavy;
                @Heavy.canceled += instance.OnHeavy;
            }
        }
    }
    public GamepadDefaultsActions @GamepadDefaults => new GamepadDefaultsActions(this);
    public interface IKeyboardActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMedium(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
    }
    public interface IGamepadActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMedium(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
    }
    public interface IPlayerTwoActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMedium(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
    }
    public interface IGamepadDefaultsActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnBurst(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMedium(InputAction.CallbackContext context);
        void OnHeavy(InputAction.CallbackContext context);
    }
}
