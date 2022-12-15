import LogoImg from "../Images/MovieLogoTatos.png";
function LoadGame() {
    window.open("https://mohazahid.github.io/Tatos/FinalBuild/index.html");
}
export default function Game() {
    return (
    <div className = "GamePage">
        <div className = "TextDiv">
            <box className = "TextBox">
                <img src={LogoImg} width={500} height={650} alt="passedImg"/>
                
            </box>
            <button className = "LinkButton" onClick = {LoadGame}>
                Play The Game
            </button>
        </div>
    </div>
    )
}