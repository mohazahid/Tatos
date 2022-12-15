import { Link, useMatch, useResolvedPath } from "react-router-dom";
import LogoImg from "./Images/TatosLogo.png";
export default function Navbar() {
    return (
        <nav className="nav"> 
        <Link to= "/" className= "SiteTitle">  <img src={LogoImg} width={130} height={50} alt="passedImg"/></Link>
        <ul>
                <CustomLink to= "/game"> Game </CustomLink>
                <CustomLink to= "/credits"> Credits </CustomLink>
                <CustomLink to= "/logs"> Logs </CustomLink>
        </ul>
        </nav>
    );
}

function CustomLink({to, children, ...props}) {
    const resolvedPath =useResolvedPath(to);
    const isActive = useMatch({path: resolvedPath.pathname, end: true});
    return (
        <li className ={isActive? "active" : ""}>
            <Link to = {to} {...props}>
                {children}
            </Link>
        </li>
    );
}

