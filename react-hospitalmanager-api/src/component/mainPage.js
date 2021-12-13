import React from 'react'
import './mainPage.css'

export default class mainPage extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return <div class="anim-show">
            {/* <img src="https://nv.ua/system/MediaPhoto/images/000/044/723/original/b9e44286002579f4143caece702a2a7e.png" alt="" /> */}
            <img src="https://localhost:44333/mainPage.png" alt="" />
        </div>
    }
}